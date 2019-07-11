using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float humidity;
        private readonly ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: {0}F degrees and {1:p} humidity", temperature, humidity);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey", "811023472@qq.com"));
            message.To.Add(new MailboxAddress("Alice", "ppo881202@163.com"));
            message.Subject = "How you doin?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Alice,

                        What are you up to this weekend? Monica is throwing one of her parties on
                        Saturday and I was hoping you could make it.

                        Will you be my +1?

                        -- Joey
                        "
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.qq.com", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("811023472@qq.com", "saxlbxqvfuwxbdhi");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            Display();
        }
    }
}
