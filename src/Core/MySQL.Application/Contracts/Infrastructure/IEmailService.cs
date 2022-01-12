using MySQL.Application.Models.Mail;
using System.Threading.Tasks;

namespace MySQL.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
