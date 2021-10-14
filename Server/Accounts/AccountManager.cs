using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReimaginedAdventure.Server.Options;

namespace ReimaginedAdventure.Server
{
    public class AccountManager
    {
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountManager> _logger;
        private readonly Authentication _authenticationOptions;

        private IUserEmailStore<IdentityUser> _userEmailStore => _userStore as IUserEmailStore<IdentityUser>;
        private AccountLoginResult FailToLoginResult =>
            new AccountLoginResult
            {
                WasSuccessful = false,
                Errors = new[] { "Unable to log into account, contact support." }
            };

        public async Task LogoutUserAsync()
        {
            _logger.LogDebug("Signing out user.");
            await _signInManager.SignOutAsync();
        }

        public AccountManager(
            ILogger<AccountManager> logger,
            IUserStore<IdentityUser> userStore,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IOptions<Authentication> authenticationOptions
        )
        {
            _userStore = userStore;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _authenticationOptions = authenticationOptions.Value;
        }

        public async Task<AccountLoginResult> LoginUserAsync(LoginData data)
        {
            var signInResult =  await _signInManager.PasswordSignInAsync(
                    userName: data.Email,
                    password: data.Password,
                    isPersistent: data.RememberMe,
                    lockoutOnFailure: _authenticationOptions.EnableLockoutOnFailure
                );

            if (signInResult == SignInResult.Success)
            {
                _logger.LogDebug($"User [{data.Email}] logged in.");
                return new AccountLoginResult { WasSuccessful = true };
            }
            else
            {
                this.LogReasoning(signInResult, data);
                return FailToLoginResult;
            }
        }

        private void LogReasoning(SignInResult signInResult, LoginData data)
        {
            string message = GetMessage(signInResult, data);
            _logger.LogDebug(message);
        }

        private string GetMessage(SignInResult signInResult, LoginData data)
        {
            if (signInResult == SignInResult.LockedOut)
            {
                return $"User account [{data.Email}] was locked out.";
            }
            else if (signInResult == SignInResult.NotAllowed)
            {
                return $"User account [{data.Email}] is not allowed.";
            }
            else if (signInResult == SignInResult.Failed)
            {
                return $"User account [{data.Email}] failed to log in without provided reason.";
            }
            else
            {
                // we are either requiring 2 factor auth (that isn't supported) or
                // we have a sign in result that isn't accounted for, in both
                // cases, we throw
                throw new NotImplementedException("We don't want to end up here, wtf...");
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
