using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;

namespace stocklily.Services
{
    public class FirebaseAuthService
    {
        private readonly string _apiKey = "AIzaSyBHKASNntZMK3d638hsIkZbnCWqwOamquM";

        private FirebaseAuthProvider _authProvider;

        public FirebaseAuthService()
        {
            _authProvider = new FirebaseAuthProvider(new FirebaseConfig(_apiKey));
        }

        // Sign Up Email n pw
        public async Task<FirebaseAuthLink> SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var authLink = await _authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                return authLink;
            }
            catch (FirebaseAuthException ex)
            {
                throw new Exception($"Sign-up failed: {ex.Reason}");
            }
        }

        // Sign In Email n pw
        public async Task<FirebaseAuthLink> SignInWithEmailPassword(string email, string password)
        {
            try
            {
                var authLink = await _authProvider.SignInWithEmailAndPasswordAsync(email, password);
                return authLink;
            }
            catch (FirebaseAuthException ex)
            {
                throw new Exception($"Sign-in failed: {ex.Reason}");
            }
        }

        // Get user information
        public async Task<User> GetUser(string token)
        {
            try
            {
                var user = await _authProvider.GetUserAsync(token);
                return user;
            }
            catch (FirebaseAuthException ex)
            {
                throw new Exception($"Failed to retvieve user: {ex.Reason}");
            }
        }

        // Invalidate user token (sign out)
        public void SignOut()
        {
            // Remove token from cache
        }

    }
}
