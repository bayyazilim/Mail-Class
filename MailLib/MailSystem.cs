using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailLibrary
{
    public class MailSystem
    {
        //Gönderen Mail Adress A
        public string GMailAdress { get; set; }
        public string GMailPass { get; set; }

        //Alan Mail Adress B
        public string AMailAdress { get; set; }

        //Mail İçeriği
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public string Imza { get; set; }

        //Host ve Port
        private string Host { get; set; }
        private int Port { get; set; }

        private void GetHostPort(string GMA)
        {
            //char[] ayrac = { '@' };


            string Domain = GMailAdress.Split(new char[] { "@"[0] }).Last();

            switch (Domain)
            {
                case "gmail.com":
                    Host = "smtp.gmail.com";
                    Port = 587;
                    break;
                case "outlook.com":
                    Host = "smtp-mail.outlook.com";
                    Port = 587;
                    break;
                case "hotmail.com":
                    Host = "smtp.live.com";
                    Port = 587;
                    break;
                case "outlook.com.tr":
                    Host = "smtp-mail.outlook.com";
                    Port = 587;
                    break;
                case "yandex.com":
                    Host = " smtp.yandex.com";
                    Port = 587;
                    break;
            }

        }

        //Custom host ve port belirleme
        public void CustomHP(string _Host, int _Port)
        {
            if (_Host != "")
                Host = _Host;

            if (_Port <= 0)
                Port = _Port;
        }

        public void MailPost()
        {
            //Mail adresinden char ile @ den sonrasını alıp host linkini almak.
            GetHostPort(GMailAdress);
            SmtpClient smtp = new SmtpClient();


            using (MailMessage mm = new MailMessage(GMailAdress, AMailAdress))
            {
                mm.Subject = Konu;
                mm.Body = Icerik + Imza;

                mm.IsBodyHtml = false;
                smtp.Host = Host;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(GMailAdress, GMailPass);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = Port;

                string kontrol = "Gönderildi";

                try
                {
                    smtp.Send(mm);
                }

                catch (SmtpException ex)
                {
                    kontrol = "Hata : " + ex.Message;
                }

            }
        }
    }
}
