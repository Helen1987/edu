using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Windows.Forms;
using System.Net.Mail;

namespace CodeHelp
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
		/// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		public Connect()
		{
		}

		/// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
			_applicationObject = (DTE2)application;
			_addInInstance = (AddIn)addInInst;
			if(connectMode == ext_ConnectMode.ext_cm_UISetup)
			{
                // Create a command bar on the code window
                //CommandBar oCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["Code Window"];
                CommandBar oCommandBar = ((CommandBars)_applicationObject.CommandBars)["Code Window"];
                CommandBarPopup oPopup = (CommandBarPopup)
                oCommandBar.Controls.Add(MsoControlType.msoControlPopup, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, true);
                // Set the caption of the menu item
                oPopup.Caption = "Code helpers";
                // Build a sub menu attached to the menu above
                CommandBarControl oControl =
                         oPopup.Controls.Add(MsoControlType.msoControlButton, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, true);
                // Set the caption of the sub menu item
                oControl.Caption = "Send to the Guru";

                // Attach a handler to deal with the sub menu
                oSubMenuItemHandler = (CommandBarEvents)_applicationObject.Events.get_CommandBarEvents(oControl);
                oSubMenuItemHandler.Click += new _dispCommandBarControlEvents_ClickEventHandler(oSubMenuItemHandler_Click);
			}
		}

		/// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
		}

		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}
		
		/// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
		/// <param term='commandName'>The name of the command to determine state for.</param>
		/// <param term='neededText'>Text that is needed for the command.</param>
		/// <param term='status'>The state of the command in the user interface.</param>
		/// <param term='commandText'>Text requested by the neededText parameter.</param>
		/// <seealso class='Exec' />
		public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
		{
			if(neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
			{
				if(commandName == "CodeHelp.Connect.CodeHelp")
				{
					status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported|vsCommandStatus.vsCommandStatusEnabled;
					return;
				}
			}
		}

		/// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
		/// <param term='commandName'>The name of the command to execute.</param>
		/// <param term='executeOption'>Describes how the command should be run.</param>
		/// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
		/// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
		/// <param term='handled'>Informs the caller if the command was handled or not.</param>
		/// <seealso class='Exec' />
		public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
			handled = false;
			if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
			{
				if(commandName == "CodeHelp.Connect.CodeHelp")
				{
					handled = true;
					return;
				}
			}
		}
	

        /// <summary>
        /// Handle on click events of our menu handle
        /// </summary>
        // event handler for Click event.
        protected void oSubMenuItemHandler_Click(object theCommandBarControl,
                                   ref bool handled, ref bool cancelDefault)
        {
            // Get the control object passed in as a parameter
            CommandBarControl theCtrl = (CommandBarControl)theCommandBarControl;
            // Get the current document...
            Document theDoc = _applicationObject.ActiveDocument;
            // See if any selected text
            TextSelection sel = (TextSelection)theDoc.Selection;
            if (sel.Text == "")
            {
                MessageBox.Show("Please select some text...", "Error");
                handled = true;
                return;
            }

            // Let's make an e-mail for the guru
            string subjectLine = "Having trouble understanding this code";
            string msgbody = "<p>Can you review it and tell me what the #$@* it is doing<p>" + Environment.NewLine +
                                Environment.NewLine + "<pre>" + sel.Text + "</pre>" + Environment.NewLine + "<p>Thanks...";


            MailMessage mail = new MailMessage();
            mail.To.Add(GuruEmail);
            mail.From = new MailAddress(Environment.UserName + "@" + fromDomain);
            mail.Subject = subjectLine;
            mail.Body = msgbody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address 
            smtp.Credentials = new System.Net.NetworkCredential
                 ("user-e-mail", "password");                       // TODO: Fill in credentials
            //Or your Smtp Email ID and Password 
            smtp.EnableSsl = true;
            smtp.Send(mail);

            // Now we add the comment back to the code
            string commentChar = "//";
            string theTodoText = _applicationObject.ToolWindows.TaskList.DefaultCommentToken.ToString();
            string revisedCode = commentChar + " " + theTodoText + " sent to guru on " + DateTime.Now.ToString() + Environment.NewLine +
                                   commentChar + " < Guru answer here >" + Environment.NewLine +
                                   sel.Text +
                                   commentChar + " ********" + Environment.NewLine;

            DataObject theObj = new System.Windows.Forms.DataObject();
            try
            {
                theObj.SetData(System.Windows.Forms.DataFormats.Text, revisedCode);
                System.Windows.Forms.Clipboard.SetDataObject(theObj);
                sel.Paste();
            }
            catch
            {
                MessageBox.Show("couldn't paste comment, sorry");
            }

            TextDocument theText = (TextDocument)theDoc.Object();
            EditPoint thePoint = theText.CreateEditPoint();             // By default, first line/char of file.
            thePoint.Insert("// Using statements **********************************************" + Environment.NewLine);
            thePoint.MoveToPoint(theText.EndPoint);
            thePoint.Insert("// End of File ***************************************************" + Environment.NewLine);
            thePoint.MoveToPoint(theText.EndPoint);

            //
            handled = true;
        }

        private string fromDomain = "gmail.com";
        private string GuruEmail = "";                  // TODO: Fill in guru e-mail address
        private CommandBarEvents oSubMenuItemHandler;
        private DTE2 _applicationObject;
        private AddIn _addInInstance;
    }
}