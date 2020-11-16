using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace _07_MethodChaining.Samples
{
    public class MailBuilderSample
    {
        private string subject;
        private string body;
        private string fromAddress = "test@foo.com";
        private string fromDisplayName = "TEST";
        private List<string> toAddresses { get; set; } = new List<string>();
        private List<string> toCCAddresses { get; set; } = new List<string>();
        private List<string> toBCCAddresses { get; set; } = new List<string>();
        private bool IsHtml { get; set; }

        private MailBuilderSample() { }
        public static MailBuilderSample Init(string title, string toAddress)
        {
            var result = new MailBuilderSample();
            result.subject = title;
            result.AddToAddress(toAddress);
            return result;
        }
        public MailBuilderSample AddToAddress(string toAddress)
        {
            if (CheckMailAddress(toAddress))
            {
                this.toAddresses.Add(toAddress);
            }
            return this;
        }
        public MailBuilderSample AddToCCAddress(string toCCAddress)
        {
            if (CheckMailAddress(toCCAddress))
            {
                this.toCCAddresses.Add(toCCAddress);
            }
            return this;
        }
        public MailBuilderSample AddToBCCAddress(string toBCCAddress)
        {
            if (CheckMailAddress(toBCCAddress))
            {
                this.toBCCAddresses.Add(toBCCAddress);
            }
            return this;
        }
        public MailBuilderSample SetFromAddress(string fromAddress)
        {
            this.fromAddress = fromAddress;
            return this;
        }
        public MailBuilderSample SetFromDisplayName(string fromDisplayName)
        {
            this.fromDisplayName = fromDisplayName;
            return this;
        }
        public MailBuilderSample SetBody(string body)
        {
            this.body = body;
            return this;
        }
        public MailBuilderSample SetIsHtml(bool isHtml = true)
        {
            this.IsHtml = IsHtml;
            return this;
        }
        private bool CheckMailAddress(string mailAddress)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(mailAddress, @".+\@.+\..+");
        }
        public void SendMail()
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = this.subject;
            mailMessage.Body = this.body;
            mailMessage.IsBodyHtml = this.IsHtml;
            foreach (var toAddress in this.toAddresses)
            {
                mailMessage.To.Add(toAddress);
            }
            foreach (var toCCAddress in this.toCCAddresses)
            {
                mailMessage.CC.Add(toCCAddress);
            }
            foreach (var toBCCAddress in this.toBCCAddresses)
            {
                mailMessage.Bcc.Add(toBCCAddress);
            }
            mailMessage.From = new MailAddress(this.fromAddress, this.fromDisplayName);

            //Trzeba uzupełnić konfigurację serwera pocztowego przed wysyłką
            //var smtpClient = new SmtpClient();
            //smtpClient.Send(mailMessage);
        }

    }
}
