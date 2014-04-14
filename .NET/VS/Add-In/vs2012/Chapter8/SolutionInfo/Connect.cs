using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Windows.Forms;
using System.Text;
using VSLangProj;
using System.IO;

namespace SolutionInfo
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
        const int LIGHTBULB_ICON = 1000;

        // Constants for Additional project types
        const string WEB_APPLICATION_PROJECT = "{E24C65DC-7377-472b-9ABA-BC803B73C61A}";
        const string DEPLOYMENT_PROJECT = "{54435603-DBB4-11D2-8724-00A0C9A8B90C}";
        
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
				string toolsMenuName = "Tools";

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
                    Command command = commands.AddNamedCommand2(_addInInstance, "SolutionInfo", "SolutionInfo", "Executes the command for SolutionInfo", true, LIGHTBULB_ICON, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);

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
				if(commandName == "SolutionInfo.Connect.SolutionInfo")
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
				if(commandName == "SolutionInfo.Connect.SolutionInfo")
				{

                    // Only makes sense if a solution is open
                    if (_applicationObject.Solution.IsOpen == false)
                    {
                        MessageBox.Show("No solution is open", "ERROR");
                        handled = true;
                        return;
                    }

                    StringBuilder sb = new StringBuilder();
                    Solution theSol = _applicationObject.Solution;

                    sb.AppendLine("         Solution: " + Path.GetFileName(theSol.FullName.ToString()));
                    sb.AppendLine("        Full Path: " + theSol.FullName.ToString());
                    sb.AppendLine("Start-up projects: ");
                    foreach (String s in (Array)theSol.SolutionBuild.StartupProjects)
                    {
                        sb.AppendLine("                   " + s);
                    }

                    Project theProj;                        // Generic project item
                    int NumVBprojects = 0;
                    int NumVBmodules = 0;
                    int NumCSprojects = 0;
                    int NumCSmodules = 0;
                    int NumOtherProjects = 0;

                    // Iterate through the projects, to determine number of each kind
                    for (int x = 1; x <= theSol.Count; x++)
                    {
                        theProj = theSol.Item(x);
                        switch (theProj.Kind)
                        {
                            case PrjKind.prjKindVBProject:
                                {
                                    NumVBprojects++;    // Increment number of VB projects
                                    NumVBmodules += theProj.ProjectItems.Count;
                                    break;
                                }
                            case PrjKind.prjKindCSharpProject:
                                {
                                    NumCSprojects++;    // Increment number of C# projects
                                    NumCSmodules += theProj.ProjectItems.Count;
                                    break;
                                }
                            default:
                                {
                                    NumOtherProjects++;
                                    break;
                                }
                        }
                    }

                    sb.AppendLine("Visual Basic code");
                    sb.AppendLine("     " + NumVBprojects.ToString() + " projects containing " +
                                            NumVBmodules.ToString() + " modules");
                    sb.AppendLine("");
                    sb.AppendLine("Visual C# code");
                    sb.AppendLine("     " + NumCSprojects.ToString() + " projects containing " +
                                            NumCSmodules.ToString() + " modules");
                    sb.AppendLine("");
                    sb.AppendLine("Miscellaneous projects");
                    sb.AppendLine("     " + NumOtherProjects.ToString() + " other projects");
                    sb.AppendLine("");

                    // Get properties
                    sb.AppendLine("Solutuion Properties");
                    Properties props = theSol.Properties;
                    foreach (Property prop in props)
                    {
                        sb.Append("   " + prop.Name + " = ");
                        try
                        {
                            sb.AppendLine(prop.Value.ToString());
                        }
                        catch
                        {
                            sb.AppendLine("(Nothing)");
                        }
                    }

                    // Put built string onto form
                    SolInfoForm theForm = new SolInfoForm();
                    theForm.SOLINFO.Text = sb.ToString();
                    theForm.ShowDialog();

                    handled = true;
                    return;

				}
			}
		}
		private DTE2 _applicationObject;
		private AddIn _addInInstance;
	}
}