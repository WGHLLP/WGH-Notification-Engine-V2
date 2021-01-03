using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WGH_Notification_Engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public string PeopleToContact; // List of people to contact with a message (At least one mandatory)
        public int msgFromUserID; // User ID for the person that is sending the message (Mandatory). If userid = "0" then SYSTEM sent the message.
        public int MessageType; // They type of message that is being sent (Mandatory):
                                // 1.	Custom message(must provide message text)
                                // 2.	New user invite
                                // 3.	Share on social media - player or manager instigated
                                // 4.	Share game info to existing users
                                // 5.	Player Cancels their acceptance to play
                                // 6.	Ask player if they want to add User to Friend List(Not a two way relationship)
                                // 7.	Player accepts game
                                // 8.	Player accepts game(notify manager) & player wants to share game – perhaps this is two calls to the module from the instigating routine.
                                // 9.	Manager cancels game – notify player(s)
        public string MessageText; // Free form text that will be used (Mandatory for custom messages)
        public int msgGameID; // ID for the game information stored on file. Only required when game info needed.
        public int msgPriority; // The priority of the message will determinte the type of message sent.
                                // Lower priority messages will be included. I.e Pri 1 will include Popup, Toast & In-App messsge (Mandatory). 
                                // 1.   Popup
                                // 2.   Toast - Red circle notification on app icon
                                // 3.   In-App message



        public string NotificationMessage(string PeopleToContact, int msgFromUserID, int msgType, string MessageText, int msgGameID, int msgPriority)
        {
            // We need to loop through each person that is due to receive the message.
            // People to contact can be multiple users with comma seperators.
            // Can be an e-mail address, Telephone number or User ID.
            // To be sure we use the right type, we will require a prefix for each user. Using the following guidance:
            // TEL nnnnnnnnn
            // EMAIL xxxxxx@xxxxx.xxx
            // ID nnnnnn

            // This code splits the entry in to seperate elements of an array.
            string[] peopleToContactArray;
            peopleToContactArray = PeopleToContact.Split(',', StringSplitOptions.RemoveEmptyEntries);


            var message = new StringBuilder();

            // loop through each contact and send them a message.
            for (int i = 0; i < peopleToContactArray.Length; i++)
            {
                message = new StringBuilder();
                string personToContact = peopleToContactArray[i];
                string[] contactTypeArray;
                contactTypeArray = personToContact.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string contactType = contactTypeArray[0].ToUpper();
                string msgTo = contactTypeArray[1];
                bool addToUser = true;


                // Setup variables ready to write to DB

                string msgBody;


                switch (msgType)
                {
                    case 1: // Custom Message
                        msgBody = MessageText;
                        break;
                    case 2: // New User Invite.
                        msgBody = "You have been invited to join.";
                        break;
                    case 3: // Share on social Media
                        msgBody = "User " + msgFromUserID + " has decided to share game " + msgGameID + " on social media.";
                        addToUser = false;
                        break;
                    case 4: // Share game info to existing user
                        if (msgFromUserID == 0)
                        {
                            msgBody = "SYSTEM generated : A game is available that matches your requirements. See game " + msgGameID;
                        }
                        else
                        {
                            msgBody = "A game is available that matches your requirements. See game " + msgGameID + " from User " + msgFromUserID;
                        }
                        break;

                    case 5: // Player cancels their acceptance to play
                        msgBody = "Player " + msgFromUserID + " has cancelled invite to game " + msgGameID + " they previously accepted.";
                        break;
                    case 6: // Ask player if they want to add player to friend list.
                        msgBody = "Do you want to add player to your friend list.";
                        break;
                    case 7: // Player accepts game - let manager know
                        msgBody = "Player " + msgFromUserID + " has accepted game - " + msgGameID;
                        break;
                    case 8: // Player accepts game - let manager know & player wants to share on social media
                        msgBody = "Player " + msgFromUserID + " has accepted game - " + msgGameID + " and has chosen to post on social media.";
                        break;
                    case 9: // Manager cancels game - notify player(s)
                        msgBody = "Manager " + msgFromUserID + " has canceled the game " + msgGameID;
                        break;
                    default: // This should not occur and is an error - use exception catching.
                        msgBody = "Message type does not exist.";
                        addToUser = false;
                        break;
                }

                int msgMode = 0;

                if (addToUser)
                {
                    message.Append("Sent to user : " + msgTo);

                    // What type of contact will we make. Phone, e-mail or app messaging.

                    switch (contactType)
                    {
                        case "EMAIL":
                            msgMode = 1;
                            // See here on how to send an automated e-mail
                            // https://www.c-sharpcorner.com/article/sending-email-using-c-sharp/
                            break;

                        case "TEXT":
                            msgMode = 2;
                            // see here how to send an automated text message
                            // https://www.c-sharpcorner.com/article/send-text-message-to-cell-phones-from-a-C-Sharp-application/
                            break;

                        case "APP":
                            msgMode = 3;
                            break;

                        default:
                            msgMode = 3;
                            break;

                    }
                }
                else
                {
                    msgTo = null;

                }
                if (msgPriority != 1 && msgPriority != 2 && msgPriority != 3) msgPriority = 3;

                // using UTC to ensure consistency accross timezones. 
                string msgDateTime = DateTime.UtcNow.ToString();

                SaveAppMessage(msgType, msgTo, msgBody, msgMode, msgFromUserID, msgPriority, msgDateTime, msgGameID);
                UpdateDB("insert", 0, msgType, msgBody, msgTo, msgMode, msgFromUserID, msgPriority, msgDateTime, msgGameID);
            }
            return message.ToString();
        }

        // Show an in app message only

        public string SaveAppMessage(int msgType, string msgTo, string msgBody, int msgMode, int msgFromUserID, int msgPriority, string msgDateTime, int msgGameID)
        {
            return null;
        }

        public string UpdateDB(string updateType, int msgID, int msgType, string msgBody, string msgTo, int msgMode, int msgFromID, int msgPriority, string msgDateTime, int msgGameID)
        {

            string connectionString = null;

            string ServerName = "subsfc.database.windows.net";
            string DatabaseName = "SubsFCTest";
            string UserName = "stephenseed";
            string Password = "VeA6NPuY4gQ7wYr";

            connectionString = "Data Source=" + ServerName + "; Initial Catalog=" + DatabaseName + ";User ID=" + UserName + ";Password=" + Password + ";";
            SqlConnection cnn = new SqlConnection(connectionString);

            cnn.Open(); // open database
            SqlCommand cmd = cnn.CreateCommand();
            string sql;
            switch (updateType)
            {
                case "insert":
                    sql = "INSERT INTO Notifications (msgType, msgBody, msgTo, msgMode, msgFromID, msgPriority, msgDateTime, msgGameID) " +
                "VALUES ('" + msgType + "' , '" + msgBody + "' , '" + msgTo + "' , '" + msgMode + "' , '" + msgFromUserID + "' , '" + msgPriority + "' , '" + msgDateTime + "' , '" + msgGameID + "')";
                    break;
                case "update":
                    sql = "UPDATE.....";
                    break;
                case "delete": // Delete - only for GDPR - Admin only.
                    sql = "DELETE.....";
                    break;
                case "read":
                    sql = "SELECT....";
                    break;
                case "archive":
                    sql = "ARCHIVE";
                    break;
                default:
                    sql = "";
                    break;

            }
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return null;
        }

        public string SaveAppMessage(string messageToSave)
        {
            // open message file & read user record

            // add message to file

            // write record

            // close file

            return messageToSave.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PeopleToContact = textBoxWhoTo.Text;
            if (textBoxSender.Text.ToUpper() == "SYSTEM")
            {
                textBoxSender.Text = "0";
            }
            int FromUserID = int.Parse(textBoxSender.Text);
            MessageType = int.Parse(textBoxMessageType.Text);
            MessageText = textBoxMessageText.Text;
            int GameID = int.Parse(textBoxGameID.Text);
            int MessagePriority = int.Parse(textBoxMessagePriority.Text);
            NotificationMessage(PeopleToContact, FromUserID, MessageType, MessageText, GameID, MessagePriority);


        }
    }
}

