public interface ICredentialStore
{
    bool Authenticate(string userName, string userPassword, out string userData);
    void CreateUser(string userName, string userPassword, string userData);
}
