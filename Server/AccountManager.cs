using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ReimaginedAdventure.Server
{
    public class AccountManager
    {
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _userEmailStore;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountManager(IUserStore<IdentityUser> userStore, UserManager<IdentityUser> userManager)
        {
            _userStore = userStore;
            _userEmailStore = userStore as IUserEmailStore<IdentityUser>;
            _userManager = userManager;
        }
        public async Task<AccountCreationResult> RegisterNewUser(RegistrationData data)
        {
            var newUser = Activator.CreateInstance<IdentityUser>();
            await _userStore.SetUserNameAsync(newUser, data.Email, CancellationToken.None);
            await _userEmailStore.SetEmailAsync(newUser, data.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(newUser, data.Password);
            return new AccountCreationResult
            {
                WasSuccessful = result.Succeeded,
                Errors = result.Errors?.Select(ie => ie.Description).ToArray()
            };
        }
    }
    // TODO: pull this to separate file
    public class AccountCreationResult
    {
        public bool WasSuccessful { get; set; }
        public string[] Errors { get; set; }
    }

    // TODO: pull this to separate file
    public class RegistrationData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
