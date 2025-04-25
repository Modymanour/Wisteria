using Wisteria.Domain.Entities;

namespace Wisteria.Service.Depend_Injections.Modify
{
    public interface ModifyUser
    {
        public string Modifyname(int id,string name);
        public string ModifyEmail(int id, string email);
        public string ModifyPassword(int id,string old_password,string new_password);
    }
}
