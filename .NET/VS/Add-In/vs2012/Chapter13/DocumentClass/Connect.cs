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
using System.Collections.Generic;

namespace DocumentClass
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
            
            if (connectMode == ext_ConnectMode.ext_cm_UISetup)
            {
                // Create the command object
                object[] contextGUIDS = new object[] { };
                Commands2 commands = (Commands2)_applicationObject.Commands;
                try
                {
                    Command cmd = commands.AddNamedCommand2(_addInInstance, "DocumentClass",
                      "Class Documentator", "Document your class module ", true, 59, ref contextGUIDS,
                      (int)vsCommandStatus.vsCommandStatusSupported +
                      (int)vsCommandStatus.vsCommandStatusEnabled,
                      (int)vsCommandStyle.vsCommandStylePictAndText,
                      vsCommandControlType.vsCommandControlTypeButton);
                    // Create a command bar on the code window
                    CommandBar CmdBar = ((CommandBars)_applicationObject.CommandBars)["Code Window"];
                    // Add a command to the Code Window's shortcut menu.
                    CommandBarControl cmdBarCtl = (CommandBarControl)cmd.AddControl(CmdBar,
                                                                   CmdBar.Controls.Count + 1);
                    cmdBarCtl.Caption = "Class Doc";
                }
                catch (System.ArgumentException)
                {
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
				if(commandName == "DocumentClass.Connect.DocumentClass")
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
				if(commandName == "DocumentClass.Connect.DocumentClass")
				{
                    FileCodeModel2 fileCM = null;
                    // Make sure there is an open source code file
                    try
                    {
                        fileCM = (FileCodeModel2)_applicationObject.ActiveDocument.ProjectItem.FileCodeModel;
                    }
                    catch
                    {
                        MessageBox.Show("No active source file is open...");
                        handled = true;
                        return;
                    }
                    // Determine the language of the source file.
                    string CommentChar = "";
                    switch (fileCM.Language)
                    {
                        case CodeModelLanguageConstants.vsCMLanguageCSharp:
                            {
                                CommentChar = "//";
                                break;
                            }
                        case CodeModelLanguageConstants.vsCMLanguageVB:
                            {
                                CommentChar = "'";
                                break;
                            }
                    }

                    if (CommentChar == "")
                    {
                        MessageBox.Show("Only works with VB or C# class modules");
                        handled = true;
                        return;
                    }

                    // Scan the file, looking for a class construct, may require two passes
                    CodeElements elts = fileCM.CodeElements;
                    CodeElement elt = null;
                    int xClassElt = 0;
                    int xNameSpace = 0;
                    int nLevels = 0;
                    while (xClassElt == 0)
                    {
                        nLevels++;
                        for (int i = 1; i <= elts.Count; i++)
                        {
                            elt = elts.Item(i);
                            if (elt.Kind == vsCMElement.vsCMElementClass)
                            {
                                xClassElt = i;
                                break;
                            }
                            if (elt.Kind == vsCMElement.vsCMElementNamespace)
                            {
                                xNameSpace = i;
                                break;
                            }
                        }
                        // Found namespace and no class, let's work through the name space looking for a class
                        if (xNameSpace != 0 && xClassElt == 0)
                        {
                            elts = elts.Item(xNameSpace).Children;
                        }
                        // Don't search deeper than three levels
                        if (nLevels > 2)
                        {
                            break;
                        }
                    }
                    // If no class found first level, but a name space was found
                    if (xClassElt == 0)
                    {
                        MessageBox.Show("No class module found in source file...");
                        handled = true;
                        return;
                    }

                    // Now we are ready to build our new class structure
                    CodeClass theclass = (CodeClass)elts.Item(xClassElt);
                    object[] interfaces = { };
                    object[] bases = { };


                    // Some initial header info
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(CommentChar + " [====================================================================================");
                    if (theclass.Namespace != null)
                    {
                        sb.AppendLine(CommentChar + "         Namespace: " + theclass.Namespace.Name.ToString());
                    }
                    if (theclass.IsAbstract)
                    {
                        sb.Append(CommentChar + "    Abstract ");
                    }
                    else
                    {
                        sb.Append(CommentChar + "             ");
                    }
                    sb.AppendLine("Class: " + theclass.Name);
                    sb.AppendLine(CommentChar + "            Author: " + Environment.UserName);
                    sb.AppendLine(CommentChar + "              Date: " + DateTime.Now.ToShortDateString());
                    sb.AppendLine(CommentChar + "  ");
                    sb.AppendLine(CommentChar + " Class Information:");
                    // Information about the class
                    string docCategory = "          Inherits:";
                    foreach (CodeElement theBase in theclass.Bases)
                    {
                        sb.AppendLine(CommentChar + docCategory + " " + theBase.Name);
                        docCategory = "                   ";
                    }


                    docCategory = "        Implements:";
                    foreach (CodeElement theImpl in theclass.ImplementedInterfaces)
                    {
                        sb.AppendLine(CommentChar + docCategory + " " + theImpl.Name);
                        docCategory = "                   ";
                    }

                    sb.AppendLine(CommentChar + "  ");
                    sb.AppendLine(CommentChar + "  Public Interface:");
                    sb.AppendLine(CommentChar + "  ");


                    TextDocument theText = (TextDocument)_applicationObject.ActiveDocument.Object();


                    elts = theclass.Children;
                    // Build queues to hold various elements
                    Queue<CodeEnum> EnumStack = new Queue<CodeEnum>();
                    Queue<CodeVariable> VarStack = new Queue<CodeVariable>();
                    Queue<CodeProperty> PropStack = new Queue<CodeProperty>();
                    Queue<CodeFunction> FuncStack = new Queue<CodeFunction>();

                    foreach (CodeElement oneElt in elts)
                    {
                        // Get the code element, and determine it's type
                        switch (oneElt.Kind)
                        {
                            case vsCMElement.vsCMElementEnum:
                                {
                                    EnumStack.Enqueue((CodeEnum)oneElt);
                                    break;
                                }
                            case vsCMElement.vsCMElementVariable:
                                {
                                    VarStack.Enqueue((CodeVariable)oneElt);
                                    break;
                                }
                            case vsCMElement.vsCMElementProperty:
                                {
                                    PropStack.Enqueue((CodeProperty)oneElt);
                                    break;
                                }
                            case vsCMElement.vsCMElementFunction:
                                {
                                    FuncStack.Enqueue((CodeFunction)oneElt);
                                    break;
                                }
                            default:
                                {
                                    break;
                                };
                        }
                    }
                    docCategory = "         Variables:";
                    // Iterate through the variables looking for public variables
                    foreach (CodeVariable theVar in VarStack)
                    {
                        if (theVar.Access == vsCMAccess.vsCMAccessPublic)
                        {
                            sb.Append(CommentChar + docCategory + " " + theVar.Name + " (" + theVar.Type.AsString + ")");
                            docCategory = "                   ";
                            if (!(theVar.InitExpression == null))
                            {
                                sb.Append(" [" + theVar.InitExpression.ToString() + "]");
                            }
                            sb.AppendLine("");
                        }
                    }
                    // Iterate through the enum's ===========================================================
                    docCategory = "             Enums:";
                    foreach (CodeEnum theEnum in EnumStack)
                    {
                        if (theEnum.Access == vsCMAccess.vsCMAccessPublic)
                        {
                            sb.Append(CommentChar + docCategory + " " + theEnum.Name + " ");
                            docCategory = "                   ";
                            if (theEnum.Children.Count > 0)
                            {
                                sb.Append("(");
                                for (int xx = 1; xx <= theEnum.Children.Count; xx++)
                                {
                                    int yy = theEnum.Children.Count - xx + 1;
                                    CodeVariable theVar = (CodeVariable)theEnum.Children.Item(yy);
                                    sb.Append(theVar.Name);
                                    if (yy > 1) { sb.Append(","); }
                                }
                                sb.Append(")");
                            }
                            sb.AppendLine("");
                        }
                    }
                    // Iterate through the properties =========================================================
                    docCategory = "        Properties:";
                    foreach (CodeProperty theProp in PropStack)
                    {
                        if (theProp.Access == vsCMAccess.vsCMAccessPublic)
                        {
                            sb.Append(CommentChar + docCategory + " " + theProp.Name + " (" + theProp.Type.AsString + ")");
                            sb.AppendLine("");
                            docCategory = "                   ";

                            foreach (CodeElement theAttr in theProp.Attributes)
                            {
                                EditPoint thePointX = theText.CreateEditPoint(theAttr.StartPoint);
                                string theVal = thePointX.GetText(theAttr.EndPoint.LineCharOffset - theAttr.StartPoint.LineCharOffset);
                            }
                        }

                    }
                    // Then the rest of the functions
                    docCategory = "           Methods:";
                    foreach (CodeFunction theFunc in FuncStack)
                    {
                        if (theFunc.FunctionKind != vsCMFunction.vsCMFunctionConstructor && theFunc.Access == vsCMAccess.vsCMAccessPublic)
                        {
                            sb.Append(CommentChar + docCategory + " " + theFunc.Name);

                            docCategory = "                   ";

                            if (theFunc.Parameters.Count > 0)
                            {
                                int yy = theFunc.Parameters.Count;
                                sb.Append("(");
                                foreach (CodeParameter theParam in theFunc.Parameters)
                                {
                                    sb.Append(theParam.Name + ":" + theParam.Type.AsString);
                                    yy--;
                                    if (yy > 0) { sb.Append(","); }
                                }
                                sb.Append(")");
                            }
                            if (theFunc.Type.AsString.ToUpper().EndsWith("VOID") == false)
                            {
                                sb.Append(" ==> " + theFunc.Type.AsString);
                            }
                            sb.AppendLine("");
                        }
                    }
                    sb.AppendLine(CommentChar + " =====================================================================================]");
                    EditPoint thePoint = theText.CreateEditPoint();
                    // Check and see if a comment already exists
                    string theLine = thePoint.GetText(thePoint.LineLength);
                    bool FoundOldComment = false;
                    string OldComment = theLine + Environment.NewLine;

                    if (theLine.StartsWith(CommentChar + " [==="))           // Start of delimiter
                    {
                        while (thePoint.AtEndOfDocument == false && FoundOldComment == false)
                        {
                            thePoint.LineDown(1);
                            theLine = thePoint.GetText(thePoint.LineLength);
                            OldComment += theLine + Environment.NewLine;
                            FoundOldComment = theLine.StartsWith(CommentChar) && theLine.EndsWith("==]");
                        }
                    }
                    if (FoundOldComment)
                    {
                        thePoint = theText.CreateEditPoint(theText.StartPoint);
                        thePoint.ReplacePattern(theText.EndPoint, OldComment, sb.ToString());
                    }
                    else
                    {
                        thePoint.Insert(sb.ToString());
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