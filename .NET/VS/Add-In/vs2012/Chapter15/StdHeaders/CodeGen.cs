using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StdHeaders
{
    class CodeGen
    {
        // List of programming language generator works with
        // </summary>
        public enum ProgrammingLanguages
        {
            VisualBasic = 1,
            CSharp = 2
        }

        private ProgrammingLanguages theLang = ProgrammingLanguages.VisualBasic;
        private bool inComment = false;

        // <summary>
        // Programming language to generate code for
        // </summary>
        public ProgrammingLanguages Programming_Language
        {
            get { return theLang; }
            set { theLang = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theComment"></param>
        /// <returns></returns>
        public string SingleLineComment(string theComment)
        {
            string res = string.Empty;
            switch (theLang)
            {
                case ProgrammingLanguages.CSharp:
                    res = "// " + theComment;
                    break;
                case ProgrammingLanguages.VisualBasic:
                    res = "' " + theComment;
                    break;
            }
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string StartComment()
        {
            return StartComment("");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theComment"></param>
        /// <returns></returns>
        public string StartComment(string theComment)
        {
            string res = string.Empty;
            switch (theLang)
            {
                case ProgrammingLanguages.CSharp:
                    res = "/* " + theComment;
                    break;
                case ProgrammingLanguages.VisualBasic:
                    res = "’ " + theComment;
                    break;
            }
            inComment = true;
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string StopComment()
        {
            string res = string.Empty;
            switch (theLang)
            {
                case ProgrammingLanguages.CSharp:
                    res = "*/ ";
                    break;
                case ProgrammingLanguages.VisualBasic:
                    break;
            }
            inComment = false;
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theName"></param>
        /// <returns></returns>
        public string MakeFileName(string theName)
        {
            string res = theName;
            switch (theLang)
            {
                case ProgrammingLanguages.CSharp:
                    res += ".cs";
                    break;
                case ProgrammingLanguages.VisualBasic:
                    res += ".vb";
                    break;
            }
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="DataType"></param>
        /// <returns></returns>
        public string DeclareVariable(string varName, string DataType)
        {
            string res = DeclareVariable(varName, DataType, "");
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="DataType"></param>
        /// <param name="DefaultValue"></param>
        /// <returns></returns>
        public string DeclareVariable(string varName, string DataType, string DefaultValue)
        {
            string res = string.Empty;
            switch (theLang)
            {
                case ProgrammingLanguages.CSharp:
                    res = DataType + " " + varName;
                    if (DefaultValue.Length > 0)
                    { res += " = " + DefaultValue; }
                    res += ";";
                    break;
                case ProgrammingLanguages.VisualBasic:
                    res = "DIM " + varName + " AS " + DataType;
                    if (DefaultValue.Length > 0)
                    { res += " = " + DefaultValue; }
                    break;
            }
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeOfCall"></param>
        /// <param name="RoutineName"></param>
        /// <param name="ReturnType"></param>
        /// <returns></returns>
        public string StartRoutine(string typeOfCall, string RoutineName, string ReturnType)
        {
            string res = string.Empty;
            switch (theLang)
            {
                case ProgrammingLanguages.CSharp:
                    if (typeOfCall.StartsWith("P"))
                    { res = "public void "; }
                    else
                    { res = "public " + ReturnType + " "; }
                    res += RoutineName + "()" + Environment.NewLine;
                    res += "{";
                    break;
                case ProgrammingLanguages.VisualBasic:
                    if (typeOfCall.StartsWith("P"))
                    { res = "sub " + RoutineName; }
                    else
                    { res = "function " + RoutineName + "() as " + ReturnType; }
                    res += Environment.NewLine;
                    break;
            }
            return res;
        }
        public string EndRoutine(string typeOfCall)
        {
            string res = string.Empty;
            switch (theLang)
            {
                case ProgrammingLanguages.CSharp:
                    {
                        res += "}" + Environment.NewLine;
                        break;
                    }
                case ProgrammingLanguages.VisualBasic:
                    {
                        if (typeOfCall.StartsWith("P"))
                        { res = "end sub "; }
                        else
                        { res = "end function"; }
                        break;
                    }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theLine"></param>
        /// <returns></returns>
        public string WriteCode(string theLine)
        {
            string res = theLine;
            if (inComment)
            { res = "'" + res; }
            return res;
        }


    }
}
