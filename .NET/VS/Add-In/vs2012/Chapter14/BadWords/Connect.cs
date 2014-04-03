using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Windows.Forms;

namespace BadWords
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{

        const int RED_STAR_ICON = 6743;
        const string BAD_WORD_LIST = "(damn|stupid|idiot|fool)";
        bool AddedToTaskList = false;

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
                // Add the command
                Command cmd = (Command)_applicationObject.Commands.AddNamedCommand(_addInInstance,
                                      "BadWords", "BadWords",
                                      "Search for bad words", true, RED_STAR_ICON, null,
                                      (int)vsCommandStatus.vsCommandStatusSupported +
                                      (int)vsCommandStatus.vsCommandStatusEnabled);
                CommandBar stdCmdBar = null;
                // Reference the Visual Studio standard toolbar.
                CommandBars commandBars = (CommandBars)_applicationObject.CommandBars;
                foreach (CommandBar cb in commandBars)
                {
                    if (cb.Name == "Standard")
                    {
                        stdCmdBar = cb;
                        break;
                    }
                }
                // Add a button to the standard toolbar.
                CommandBarControl stdCmdBarCtl = (CommandBarControl)cmd.AddControl(stdCmdBar,
                                                 stdCmdBar.Controls.Count + 1);
                // Set a caption for the toolbar button.
                stdCmdBarCtl.Caption = "Search for bad words";
                // Set the toolbar's button style to an icon button.
                CommandBarButton cmdBarBtn = (CommandBarButton)stdCmdBarCtl;
                cmdBarBtn.Style = MsoButtonStyle.msoButtonIcon;

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
				if(commandName == "BadWords.Connect.BadWords")
				{
                    if (_applicationObject.Solution.Count > 0)
                    {
                       status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
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
				if(commandName == "BadWords.Connect.BadWords")
				{

                    handled = true;
                    if (_applicationObject.Solution.Count < 1)
                    {
                        MessageBox.Show("Please open a solution to scan...");
                        return;
                    }
                    // Need to get all project items and search for "bad words"
                    OutputWindow outWnd = _applicationObject.ToolWindows.OutputWindow;
                    TaskList theTasks = _applicationObject.ToolWindows.TaskList;
                    OutputWindowPane OutputPane = outWnd.OutputWindowPanes.Add("Bad words");
                    OutputPane.Clear();
                    bool FoundBadWords = false;
                    // Activate the output window
                    Window win = _applicationObject.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
                    win.Activate();

                    foreach (Project CurProject in _applicationObject.Solution)
                    {
                        foreach (ProjectItem CurItem in CurProject.ProjectItems)
                        {
                            Document theDoc = null;
                            try
                            {
                                theDoc = CurItem.Document;
                            }
                            catch
                            {
                            }
                            if (theDoc != null)
                            {
                                TextDocument theText = (TextDocument)theDoc.Object("TextDocument");
                                if (theText != null)
                                {
                                    if (theText.MarkText(BAD_WORD_LIST, (int)vsFindOptions.vsFindOptionsRegularExpression))
                                    {
                                        OutputPane.OutputString(CurItem.Name + " contains bad words" + Environment.NewLine);
                                        FoundBadWords = true;
                                    }
                                }
                            }
                        }
                    }
                    // Check 
                    if (FoundBadWords && AddedToTaskList == false)
                    {
                        TaskItems2 TLItems = (TaskItems2)theTasks.TaskItems;
                        TLItems.Add("Bad Words", "Bad Words", "Remove bad words " + BAD_WORD_LIST +
                                                " from source files",
                        vsTaskPriority.vsTaskPriorityHigh, vsTaskIcon.vsTaskIconNone,
                          true, null, 10, true, true);
                        AddedToTaskList = true;
                    }					
				}
			}

            return;
		}

		private DTE2 _applicationObject;
		private AddIn _addInInstance;

	}
}