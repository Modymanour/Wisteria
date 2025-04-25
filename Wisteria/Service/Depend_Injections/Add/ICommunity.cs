namespace Wisteria.Service.Depend_Injections.Add
{
    public interface ICommunity
    {
        public string CreateCommunity(string name);

        public string AddUserToCommunity(int User_ID, int Community_ID);
    }
}
