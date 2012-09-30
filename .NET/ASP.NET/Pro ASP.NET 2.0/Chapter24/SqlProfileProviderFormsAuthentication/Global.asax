<%@ Application Language="C#" %>

<script runat="server">

    void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs pe)
    {
        // Get the anonymous profile.
        ProfileCommon anonProfile = Profile.GetProfile(pe.AnonymousID);

        // Copy information to the authenticated profile (but only if there's information there).
        if (anonProfile.Address.Name != null)
        {
            Profile.Address = anonProfile.Address;      
        }

        // Delete the anonymous profile from the database.
        // (You could decide to skip this step to increase performance
        //  if you have a dedicated job scheduled on the database server
        //  to remove old anonymous profiles.)
        System.Web.Profile.ProfileManager.DeleteProfile(pe.AnonymousID);

        // Remove the anonymous identifier.
        AnonymousIdentificationModule.ClearAnonymousIdentifier();   
    }

</script>
