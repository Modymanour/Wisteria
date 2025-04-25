namespace Wisteria.Service.Depend_Injections.Register
{
    public interface RegisterChecker
    {
        public bool Name_validator(string name);
        public bool Email_validator(string email);
        public bool Password_validator(string password);
    }
}
