using Wisteria.Domain.Dtos;
using Wisteria.Domain.Entities;

namespace Wisteria.Service.Depend_Injections.LogIn
{
    public interface ILogIn
    {
        public User? Login(UserDtoLogin _u);
    }
}
