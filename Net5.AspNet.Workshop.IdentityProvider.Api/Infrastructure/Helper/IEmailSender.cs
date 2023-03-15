using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Helper
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}