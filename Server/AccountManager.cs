using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ReimaginedAdventure.Server
{
    public class AccountManager
    {
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _userEmailStore;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountManager> _logger;

        public async Task LogoutUserAsync()
        {
            _logger.LogInformation($"Signing out user.");
            await _signInManager.SignOutAsync();
        }

        public AccountManager(IUserStore<IdentityUser> userStore, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountManager> logger)
        {
            _userStore = userStore;
            _userEmailStore = userStore as IUserEmailStore<IdentityUser>;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<AccountLoginResult> LoginUserAsync(LoginData data)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var signInResult = await _signInManager.PasswordSignInAsync(data.Email, data.Password, data.RememberMe, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                _logger.LogInformation($"User [{data.Email}] logged in.");
                return new AccountLoginResult { WasSuccessful = true };
            }
            else
            {
                var message =
                    signInResult.IsLockedOut ?
                    $"User account [{data.Email}] locked out." :
                    $"User [{data.Email}] could not be logged in.";

                _logger.LogWarning(message);
                return new AccountLoginResult
                {
                    WasSuccessful = false,
                    Errors = new[] { message }
                };
            }
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
}
