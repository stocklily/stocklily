using stocklily.Services;
using System;
using System.Threading.Tasks;

namespace stocklily
{
    public partial class MainPage : ContentPage
    {
        private readonly FirebaseAuthService _firebaseAuthService;

        public MainPage()
        {
            InitializeComponent();
            _firebaseAuthService = new FirebaseAuthService();
        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            string email = "user@example.com";
            string password = "password123";

            try
            {
                var authLink = await _firebaseAuthService.SignUpWithEmailPassword(email, password);
                Console.WriteLine($"User signed up: {authLink.User.Email}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            string email = "user@example.com";
            string password = "password123";

            try
            {
                var authLink = await _firebaseAuthService.SignInWithEmailPassword(email, password);
                Console.WriteLine($"User signed in: {authLink.User.Email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
