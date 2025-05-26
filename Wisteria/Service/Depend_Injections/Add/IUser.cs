using Wisteria.Domain.Dtos;
using Wisteria.Domain.Entities;

namespace Wisteria.Service.Depend_Injections.Add
{
    public interface IUser
    {
        public User? register(UserDto u);

    }
}
