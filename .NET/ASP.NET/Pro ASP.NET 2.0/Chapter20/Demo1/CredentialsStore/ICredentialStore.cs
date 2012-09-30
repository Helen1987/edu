public interface ICredentialStore
{
    bool Authenticate(string userName, string userPassword);
    void CreateUser(string userName, string userPassword);
}
