using Microsoft.AspNetCore.Identity;

namespace BlazorIdentityApiDemo.Data
{
    public class FakeEmailSender : IEmailSender<ApplicationUser>
    {
        public Task SendConfirmationLinkAsync(
ApplicationUser user,
string email,
string confirmationLink)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("EMAIL CONFIRMATION");
            Console.WriteLine($"Email : {email}");
            Console.WriteLine($"Link : {confirmationLink}");
            Console.WriteLine("=================================");

            return Task.CompletedTask;
        }

        public Task SendPasswordResetLinkAsync(
        ApplicationUser user,
        string email,
        string resetLink)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("PASSWORD RESET LINK");
            Console.WriteLine($"Email : {email}");
            Console.WriteLine($"Link : {resetLink}");
            Console.WriteLine("=================================");

            return Task.CompletedTask;
        }

        public Task SendPasswordResetCodeAsync(
        ApplicationUser user,
        string email,
        string resetCode)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("PASSWORD RESET CODE");
            Console.WriteLine($"Email : {email}");
            Console.WriteLine($"Code : {resetCode}");
            Console.WriteLine("=================================");

            return Task.CompletedTask;
        }
    }
}
