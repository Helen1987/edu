using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StdHeaders
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
        const int DOCUMENTS_ICON = 1197;

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
				object []contextGUIDS = new object[] { };
				Commands2 commands = (Commands2)_applicationObject.Commands;
				string toolsMenuName = "File";

				//Place the command on the tools menu.
				//Find the MenuBar command bar, which is the top-level command bar holding all the main menu items:
				Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];

				//Find the Tools command bar on the MenuBar command bar:
				CommandBarControl toolsControl = menuBarCommandBar.Controls[toolsMenuName];
				CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;

				//This try/catch block can be duplicated if you wish to add multiple commands to be handled by your Add-in,
				//  just make sure you also update the QueryStatus/Exec method to include the new command names.
				try
				{
					//Add a command to the Commands collection:
                    Command command = commands.AddNamedCommand2(_addInInstance, "StdHeaders", "StdHeaders", "Executes the command for StdHeaders", true, DOCUMENTS_ICON, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);

					//Add a control for the command to the tools menu:
					if((command != null) && (toolsPopup != null))
					{
						command.AddControl(toolsPopup.CommandBar, 1);
					}
				}
				catch(System.ArgumentException)
				{
					//If we are here, then the exception is probably because a command with that name
					//  already exists. If so there is no need to recreate the command and we can 
                    //  safely ignore the exception.
				}
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
				if(commandName == "StdHeaders.Connect.StdHeaders")
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
				if(commandName == "StdHeaders.Connect.StdHeaders")
				{

                    StringBuilder sb = new StringBuilder();     // String to hold header
                    CodeGen Gen = new CodeGen();                // Code generation helper
                    StdHeaderForm theForm = new StdHeaderForm();
                    theForm.ShowDialog();
                    if (theForm.DialogResult == DialogResult.OK)
                    {
                        string cFile = theForm.CODEFILE.Text;
                        // Get programming language choice
                        switch (theForm.LANGCOMBO.SelectedIndex)
                        {
                            case 0:
                                { Gen.Programming_Language = CodeGen.ProgrammingLanguages.CSharp;
                                    break;
                                }
                            case 1:
                                {
                                    Gen.Programming_Language = CodeGen.ProgrammingLanguages.VisualBasic;
                                    break;
                                }
                        }

                        sb.AppendLine(Gen.StartComment());
                        sb.AppendLine(Gen.WriteCode("=============================================="));
                        sb.AppendLine(Gen.WriteCode("     Program: "  + cFile ));
                        sb.AppendLine(Gen.WriteCode("      Author: " + Environment.UserName));
                        sb.AppendLine(Gen.WriteCode("   Date/Time: " + DateTime.Now.ToShortDateString() + 
                                                    "/" + DateTime.Now.ToShortTimeString()));
                        sb.AppendLine(Gen.WriteCode(" Environment: Visual Studio " + 
                                                     _applicationObject.Edition));
                        sb.AppendLine(Gen.WriteCode("=============================================="));
                        sb.AppendLine(Gen.StopComment());
                        sb.AppendLine(Gen.WriteCode(""));

                        //Write the function prototype
                        sb.AppendLine(Gen.StartRoutine(theForm.TYPECOMBO.Text.ToUpper(), "TBD", "string"));

                        // Optionally, write standard variables
                        if (theForm.INCLUDECHECK.Checked)
                        {
                            sb.AppendLine(Gen.DeclareVariable("SourceModified", "string"));
                            sb.AppendLine(Gen.DeclareVariable("StartTime", "DateTime", "DateTime.Now()"));
                        }
                        sb.AppendLine(Gen.EndRoutine(theForm.TYPECOMBO.Text.ToUpper()));

                        cFile = Gen.MakeFileName(cFile);
                        StreamWriter objWriter = new System.IO.StreamWriter(cFile, false);

                        objWriter.Write(sb.ToString());
                        objWriter.Close();

                        ItemOperations itemOp;
                        itemOp = _applicationObject.ItemOperations;
                        itemOp.OpenFile(cFile, Constants.vsViewKindCode);
                    }
					handled = true;
					return;
				}
			}
		}
		private DTE2 _applicationObject;
		private AddIn _addInInstance;
	}
}