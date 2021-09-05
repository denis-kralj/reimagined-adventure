using ReimaginedAdventure.Shared.Models;

namespace ReimaginedAdventure.Server
{
    public static class ModelExtensions
    {
        public static RegistrationData ToRegistrationData(this AccountRegistrationModel model)
        {
            return new RegistrationData
            {
                Email = model.Email,
                Password = model.Password
            };
        }

        public static LoginData ToLoginData(this AccountLoginModel model)
        {
            return new LoginData
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            };
        }
    }
}
