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

namespace WGH_Notification_Engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public string PeopleToContact; // List of people to contact with a message (At least one mandatory)
        public int FromUserID; // User ID for the person that is sending the message (Mandatory). If userid = "0" then SYSTEM sent the message.
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
        public int GameID; // ID for the game information stored on file. Only required when game info needed.
        public int MessagePriority; // The priority of the message will determinte the type of message sent.
                                    // Lower priority messages will be included. I.e Pri 1 will include Popup, Toast & In-App messsge (Mandatory). 
                                    // 1.   Popup
                                    // 2.   Toast - Red circle notification on app icon
                                    // 3.   In-App message
// Testing Github
        public string NotificationMessage(string PeopleToContact, int FromUserID, int MessageType, string MessageText, int GameID, int MessagePriority)
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
                string contactDetails = contactTypeArray[1];
                bool addToUser = true;
                switch (MessageType)
                {
                    case 1: // Custom Message

                        message.AppendLine("This is a custom message (type 1)");
                        message.AppendLine("Message Text : " + MessageText);
                        break;

                    case 2: // New User Invite.
                        message.AppendLine("New User Invite (type 2)");
                        message.AppendLine("Message Text : You have been invited to join.");
                        break;

                    case 3: // Share on social Media
                            // do this
                        message.AppendLine("User " + FromUserID + " has decided to share game " + GameID + " on social media.");
                        addToUser = false;
                        break;

                    case 4: // Share game info to existing user
                        message.AppendLine("This is a game available message (type 4)");
                        if (FromUserID == 0)
                        {
                            message.AppendLine("SYSTEM generated message : A game is available that matches your requirements. See game " + GameID);
                        }
                        else
                        {
                            message.AppendLine("Message Text : A game is available that matches your requirements. See game " + GameID + " from User " + FromUserID);
                        }
                        break;

                    case 5: // Player cancels their acceptance to play

                        message.AppendLine("Player Cancels and acceptance (type 5)");
                        message.AppendLine("Message Text : Player " + FromUserID + " has cancelled invite to game " + GameID + " they previously accepted.");
                        break;

                    case 6: // Ask player if they want to add player to friend list.
                        message.AppendLine("Ask player if they want to add user to friend list. (type 6)");
                        message.AppendLine("Message Text : Do you want to add player to your friend list.");
                        // do this
                        break;
                    case 7: // Player accepts game - let manager know
                        message.AppendLine("Player has accepted a game. (type 7)");
                        message.AppendLine("Message Text : Player " + FromUserID + " has accepted game - " + GameID);
                        break;
                    case 8: // Player accepts game - let manager know & player wants to share on social media
                        message.AppendLine("Player has accepted a game & social media post (type 8)");
                        message.AppendLine("Message Text : Player " + FromUserID + " has accepted game - " + GameID + " and has chosen to post on social media.");
                        // do this
                        break;
                    case 9: // Manager cancels game - notify player(s)
                        message.AppendLine("Manager cancels a game. (type 9)");
                        message.AppendLine("Message Text : Manager " + FromUserID + " has canceled the game " + GameID);
                        // do this
                        break;
                    default: // This should not occur and is an error - use exception catching.
                        message.AppendLine("Error - Message type does not exist (type " + MessageType + ")");
                        message.AppendLine("Message Text : Message type does not exist.");
                        addToUser = false;
                        // do this
                        break;
                }


                if (addToUser)
                {
                    message.Append("Sent to user : " + contactDetails);

                    // What type of contact will we make. Phone, e-mail or app messaging.

                    switch (contactType)
                    {
                        case "EMAIL":
                            message.AppendLine(" using : EMAIL");

                            // See here on how to send an automated e-mail
                            // https://www.c-sharpcorner.com/article/sending-email-using-c-sharp/

                            break;

                        case "TEXT":
                            message.AppendLine(" using : TEXT");

                            // see here how to send an automated text message
                            // https://www.c-sharpcorner.com/article/send-text-message-to-cell-phones-from-a-C-Sharp-application/

                            break;

                        case "APP":
                            message.AppendLine(" using : APP");
                            break;

                        default:
                            message.AppendLine(" using : APP - no method selected for sending defaults to APP.");
                            break;

                    }
                }
                    message.AppendLine("From User : " + FromUserID);
                    switch (MessagePriority)
                    {
                        case 1: // Popup message, Toast & in app message
                            message.AppendLine("Message Priority : 1");
                            message.AppendLine("Pop up Message - NOT Delivered");
                            message.AppendLine("Toast Message - NOT Delivered");
                            message.AppendLine("In App message - NOT delivered");
                            break;
                        case 2: // Toast - red circle notification & in app message
                            message.AppendLine("Message Priority : 2");
                            message.AppendLine("Toast Message - NOT Delivered");
                            message.AppendLine("In App message - NOT delivered");
                        break;
                        case 3: // In app message only
                            message.AppendLine("Message Priority : 3");
                            message.AppendLine("In App message - NOT delivered");
                        break;
                        default:
                            message.AppendLine("Message Priority : 3 - No message priority selected and defaults to 3");
                            message.AppendLine("In App message - NOT delivered");
                        break;
                    }             
                // using UTC to ensure consistency accross timezones.

                message.AppendLine(DateTime.UtcNow.ToString());

                string path = @"UserMessages.txt";
                string fullPath = Path.GetFullPath(path);


                SaveAppMessage(message.ToString(), personToContact);


                // TODO: This can be deleted once implemented fully with the file structure.
                message.AppendLine("File : " + fullPath);
                MessageBox.Show(message.ToString());

            }
            return message.ToString();
        }

        // Show an in app message only

        public string SaveAppMessage(string messageToSave,string personToContact)
        {
            // open message file & read user record - personToContact will only be used with a DB as a key to a record.
            // file will need to be created during the installation process. It will be created in the default location "UserMessages.txt"

            string path = @"UserMessages.txt";

            // TODO: Need to check if the file exists before doing anything. If it does not exist, then it needs to be created.
            try
            {
                using (StreamWriter sr = File.AppendText(path))
                {
                    sr.WriteLine(messageToSave);
                    sr.Close();
                }
            }
            catch(System.IO.DirectoryNotFoundException ex)
            {
                string message = "Directory Not Found. Create First." + ex;
                MessageBox.Show(message.ToString());
            }
            catch(System.IO.FileNotFoundException ex)
            {
                string message = "File Not Found. Create First." + ex;
                MessageBox.Show(message.ToString());
            }
            return messageToSave.ToString();
        }


        // Show a an in app message AND a toast notification. (Red circle on app icon).

        public string SaveAppMessage(string messageToSave)
        {
            // open message file & read user record

            // add message to file

            // write record

            // close file

            return messageToSave.ToString();
        }
        // Mobile phone Popup message AND in app message AND a toast notification. (Red circle on app icon).







        private void btnOK_Click(object sender, EventArgs e)
        {
            PeopleToContact = textBoxWhoTo.Text;
            if (textBoxSender.Text.ToUpper() == "SYSTEM")
            {
                textBoxSender.Text = "0";
            }
            FromUserID = int.Parse(textBoxSender.Text);
            MessageType = int.Parse(textBoxMessageType.Text);
            MessageText = textBoxMessageText.Text;
            GameID = int.Parse(textBoxGameID.Text);
            MessagePriority = int.Parse(textBoxMessagePriority.Text);
            NotificationMessage(PeopleToContact, FromUserID, MessageType, MessageText, GameID, MessagePriority);


        }
    }
}
