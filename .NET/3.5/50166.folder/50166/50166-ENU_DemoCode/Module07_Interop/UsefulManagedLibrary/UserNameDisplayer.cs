using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UsefulManagedLibrary
{
    [ComVisible(true)]
    public interface IUserNameDisplayer
    {
        void DisplayUserName();
    }

    /// <summary>
    /// A managed class which displays a message box with the name of the currently
    /// logged-on user.  The class is accessible to COM clients.
    /// </summary>
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class UserNameDisplayer : IUserNameDisplayer
    {
        public void DisplayUserName()
        {
            MessageBox.Show("The user name is: " + Environment.UserName, "User name");
        }
    }
}
