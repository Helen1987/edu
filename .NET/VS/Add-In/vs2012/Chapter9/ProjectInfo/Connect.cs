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
using VSLangProj;
using System.IO;

namespace ProjectInfo
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
					Command command = commands.AddNamedCommand2(_addInInstance, "ProjectInfo", "ProjectInfo", "Executes the command for ProjectInfo", true, 59, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported+(int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);

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
				if(commandName == "ProjectInfo.Connect.ProjectInfo")
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
				if(commandName == "ProjectInfo.Connect.ProjectInfo")
				{
                    // Only makes sense if a solution is open
                    if (_applicationObject.Solution.IsOpen == false)
                    {
                        MessageBox.Show("No solution is open", "ERROR");
                        handled = true;
                        return;
                    }

                    // Find all project information
                    Solution theSol = _applicationObject.Solution;
                    StringBuilder sb = new StringBuilder();
                    string shortName = Path.GetFileNameWithoutExtension(theSol.FullName);

                    sb.AppendLine("<html>");
                    sb.AppendLine("<head>");
                    sb.AppendLine("<title>" + shortName + "</title>");
                    AddJavaScript(sb);
                    AddStyles(sb);
                    sb.AppendLine("</head>");
                    sb.AppendLine("<body>");
                    sb.AppendLine("<h1>" + shortName + " solution</h1>");

                    VSProject theVSProj = null;
                    Project theProj;
                    for (int xx = 1; xx <= theSol.Projects.Count; xx++)
                    {
                        theProj = theSol.Projects.Item(xx);
                        try
                        {
                            theVSProj = (VSProject)theSol.Projects.Item(xx).Object;
                        }
                        catch
                        {
                            theVSProj = null;
                        }

                        sb.AppendLine("<h2 onclick='ToggleDiv(\"proj" + xx.ToString() + "\");'>" +
                                        theProj.Name + "</h2>");
                        sb.AppendLine("<div id='proj" + xx.ToString() + "' style='display:none;'>");
                        sb.AppendLine("<h3 onclick='ToggleDiv(\"info" + xx.ToString() + "\");'>INFO</h3>");
                        sb.AppendLine("<div id='info" + xx.ToString() + "'>");
                        sb.AppendLine("<p>Unique Name: " + theProj.UniqueName + "</br>");
                        sb.AppendLine("Full Path: " + theProj.FullName + "</br>");
                        // Report language
                        if (theProj.Kind == VSLangProj.PrjKind.prjKindCSharpProject)
                        { sb.AppendLine(" Language: C#</p>"); }
                        if (theProj.Kind == VSLangProj.PrjKind.prjKindVBProject)
                        { sb.AppendLine(" Language: Visual Basic</p>"); }
                        sb.AppendLine("</div>");

                        sb.AppendLine("<h3 onclick='ToggleDiv(\"ref" + xx.ToString() + "\");'>REFERENCES</h3>");
                        sb.AppendLine("<div id='ref" + xx.ToString() + "'>");
                        sb.AppendLine("<ul>");

                        if (theVSProj != null)
                        {
                            foreach (Reference theRef in theVSProj.References)
                            {
                                string theVer = theRef.BuildNumber.ToString();
                                if (theVer == "0")
                                { theVer = theRef.MajorVersion.ToString() + "." + theRef.MinorVersion.ToString(); }

                                sb.Append("<li>" + theRef.Name + " (" + theVer + ")");
                                if (theRef.Description.Length > 0)
                                { sb.Append(" -" + theRef.Description); }

                                if (theRef.Type == prjReferenceType.prjReferenceTypeActiveX)
                                { sb.Append(" [ActiveX] "); }
                                sb.AppendLine("</li>");
                            }
                        }

                        sb.AppendLine("<h3 onclick='ToggleDiv(\"items" + xx.ToString() + "\");'>ITEMS</h3>");
                        sb.AppendLine("<div id='items" + xx.ToString() + "' style='display:none;'>");
                        sb.AppendLine("<ul>");

                        FileCodeModel theCM = null;

                        foreach (ProjectItem theItem in theProj.ProjectItems)
                        {
                            sb.AppendLine("<li>" + theItem.Name);
                            theCM = theItem.FileCodeModel;
                            if (theCM != null)
                            {
                                sb.AppendLine("<ul>");
                                foreach (CodeElement theElt in theCM.CodeElements)
                                {   // List all the classes we find within the code file
                                    if (theElt.Kind == vsCMElement.vsCMElementClass)
                                    { sb.AppendLine("<li>" + theElt.Name + "</li>"); }
                                    // If we find a name space, possible class within there as well
                                    if (theElt.Kind == vsCMElement.vsCMElementNamespace)
                                    {
                                        foreach (CodeElement theInnerElt in theElt.Children)
                                        {
                                            string theNameSpace = theElt.Name;
                                            if (theInnerElt.Kind == vsCMElement.vsCMElementClass)
                                            {
                                                sb.AppendLine("<li>" + theNameSpace + "/" +
                                                theInnerElt.Name + "</li>");
                                            }
                                        }
                                    }
                                }
                                sb.AppendLine("</ul>");
                            }
                            sb.AppendLine("</li>");
                        }
                    }
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    
                    string theFile = Path.ChangeExtension(theSol.FullName, "html");
                    System.IO.File.WriteAllText(theFile, sb.ToString());
                    System.Diagnostics.Process.Start("file://" + theFile);


					handled = true;
					return;
				}
			}
		}


        private void AddJavaScript(StringBuilder sb)
        {
            sb.AppendLine("<script type='text/javascript'>");
            sb.AppendLine("function ToggleDiv(theID) ");
            sb.AppendLine("{");
            sb.AppendLine("var e = document.getElementById(theID);");
            sb.AppendLine("if(e.style.display == 'block')");
            sb.AppendLine("   e.style.display = 'none';");
            sb.AppendLine("else");
            sb.AppendLine("   e.style.display = 'block';");
            sb.AppendLine("}");
            sb.AppendLine("</script>");
        }

        private void AddStyles(StringBuilder sb)
        {
            sb.AppendLine("h2 {");
            sb.AppendLine("font: bold italic 2em/1em \"Times New Roman\",\"MS Serif\", \"New York\", serif;");
            sb.AppendLine("margin: 0;");
            sb.AppendLine("padding: 0;");
            sb.AppendLine("border-top: solid #e7ce00 medium;");
            sb.AppendLine("border-bottom: dotted #e7ce00 thin;");
            sb.AppendLine("width: 600px;");
            sb.AppendLine("color: #e7ce00;");
            sb.AppendLine("}");
        }

		private DTE2 _applicationObject;
		private AddIn _addInInstance;
	}
}