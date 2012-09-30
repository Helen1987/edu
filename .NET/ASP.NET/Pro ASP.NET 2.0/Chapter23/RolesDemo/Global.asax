<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(Object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(Object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(Object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (User != null)
        {
            if (User.Identity.IsAuthenticated && Roles.Enabled)
            {
                string EveryoneRoleName = ConfigurationManager.AppSettings["EveryoneRoleName"];

                if (User.IsInRole(EveryoneRoleName))
                    return;
                
                if (!Roles.IsUserInRole(EveryoneRoleName) && 
                     Roles.RoleExists(EveryoneRoleName))
                {
                    Roles.AddUserToRole(User.Identity.Name, EveryoneRoleName);
                }
            }
        }
    }

    void Session_Start(Object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(Object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

