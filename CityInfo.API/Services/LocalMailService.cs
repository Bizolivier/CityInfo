using Microsoft.AspNetCore.SignalR.Protocol;

namespace CityInfo.API.Services {
    public class LocalMailService : IMailService {
        public string _mailTo = string.Empty;
        public string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration) {

            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
    }


    public void Send(string subject, string message) {
            //send mail - output t console window

            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}" +
                $"with {nameof(LocalMailService)}.");
            Console.WriteLine($"Subject:{subject}");
            Console.WriteLine($"Message:{message}");
        }

    }
}
