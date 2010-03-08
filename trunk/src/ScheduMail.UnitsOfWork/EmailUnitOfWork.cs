using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using ScheduMail.Core.Domain;


namespace ScheduMail.UnitsOfWork
{
    /// <summary>
    /// Log Vvent unit of work.
    /// </summary>
    public class EmailUnitOfWork 
    {
        #region IlogEventUnitOfWork Members
       
       
            /// <summary>Send email via SMTP service</summary>
            /// <param name="objEmail">Email object containing email parameters</param>
            /// <returns>Success</returns>
        public bool SendMail(Email objEmail)
        {
            MailMessage mailMsg = new MailMessage();
            SmtpClient smtp;

            if (objEmail.UseBackupSMTP || objEmail.To.ToLower().Contains("@aol."))
            {
                //set up backup username, password and SMTP host
                smtp = new SmtpClient(ConfigurationSettings.AppSettings["BackupSMTP"].ToString(), 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(ConfigurationSettings.AppSettings["BackupSMTPUsername"].ToString(), ConfigurationSettings.AppSettings["BackupSMTPPassword"].ToString());
                mailMsg.From = new MailAddress(ConfigurationSettings.AppSettings["BackupSMTPAddress"]);
            }
            else
            {
                //use default web.config mail settings
                smtp = new SmtpClient();
                mailMsg.From = new MailAddress(objEmail.From);

                //set delivery method if required
                if (objEmail.FireAndForget)
                    smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            }

            mailMsg.To.Add(objEmail.To);
            mailMsg.Subject = objEmail.Subject;
            mailMsg.Body = objEmail.Body;
            mailMsg.IsBodyHtml = true;

            if (objEmail.HighPriority)
                mailMsg.Priority = MailPriority.High;

            try
            {
                smtp.Send(mailMsg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        
        #endregion
    }
}
