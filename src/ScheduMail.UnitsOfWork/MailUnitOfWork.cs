using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.Core.Domain;
using System;
using ScheduMail.Core.Facade;
using ScheduMail.Core.Service.Interfaces;
using ScheduMail.API.Contracts;

namespace ScheduMail.UnitsOfWork
{
    /// <summary>
    /// Web site unit of work.
    /// </summary>
    public class MailUnitOfWork : IMailUnitOfWork
    {
        #region IMailUnitOfWork Members

        /// <summary>
        /// Repository handle.
        /// </summary>
        private IMailRespository repository;

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>The repository.</value>
        public IMailRespository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MailUnitOfWork"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public MailUnitOfWork(IMailRespository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The Web site list.</value>
        public List<ScheduMail.Core.Domain.Mail> List
        {
            get
            {
                return this.repository.List.ToList();
            }
        }

        /// <summary>
        /// Get a Mail instance by id.
        /// </summary>
        /// <param name="id">The mail instance id.</param>
        /// <returns>mail instance.</returns>
        public ScheduMail.Core.Domain.Mail GetById(long id)
        {
            return this.repository.GetById(id);
        }

        /// <summary>
        /// Saves the specified mail.
        /// </summary>
        /// <param name="schedule">The mail instance.</param>
        /// <returns>Updated Web site instance.</returns>
        public ScheduMail.Core.Domain.Mail Save(ScheduMail.Core.Domain.Mail schedule)
        {
            var errors = this.GetRuleViolations(schedule);
            if (errors.Count > 0)
            {
                throw new RuleException(errors);
            }

            return this.repository.Save(schedule);
        }

        /// <summary>
        /// Deletes the specified mail.
        /// </summary>
        /// <param name="schedule">The schedule instance.</param>
        public void Delete(ScheduMail.Core.Domain.Mail schedule)
        {
            this.repository.Delete(schedule);
        }

        /// <summary>
        /// Gets the rule violations.
        /// </summary>
        /// <param name="schedule">The mail instance.</param>
        /// <returns>Collection of Rules Violations.</returns>
        private NameValueCollection GetRuleViolations(ScheduMail.Core.Domain.Mail schedule)
        {
            var errors = new NameValueCollection();

            return errors;
        }

        /// <summary>
        /// Emailses to be sent.
        /// </summary>
        /// <returns>list of mails</returns>
        public List<ScheduMail.Core.Domain.Mail> EmailsToBeSent()
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IScheduleUnitOfWork scheduleUnitOfWork = factory.GetScheduleUnitOfWork();
            Mail mail = null;
            //get list of all mails 
            List<Mail> listOfMails = this.List.ToList();
            //generate the list of mails to be sent to users now
            List<Mail> listOfMailsToBeSent = new List<Mail>();
            DateTime date = DateTime.Now;
            bool toBeSent = false;
            List<ScheduMail.Core.Domain.Schedule> scheduleList = scheduleUnitOfWork.GetListOfSchedule(true);
            foreach (Schedule schedule in scheduleList)
            {
                //rset the value
                toBeSent = false;

                if (schedule.StartDateTime <= date && schedule.EndDateTime == null)
                    toBeSent = true;
                else
                {
                    //validate mails are not expired
                    if (schedule.StartDateTime <= date && schedule.EndDateTime >= date )
                    {
                        //validate if its not before the time
                        if (schedule.StartDateTime.Value.TimeOfDay <= date.TimeOfDay)
                        {
                            toBeSent = true;
                        }
                    }
                }

                if (toBeSent)
                {
                    //find the mail object from schedule.MailId
                    mail = listOfMails.Find(delegate(Mail searchMail) { return searchMail.Id == schedule.MailId; });
                    switch (schedule.DailyWeeklyOrMonthly)
                    {
                        // Single
                        case "1":
                            // if mail has not been sent before then send it now.
                            if (mail.LastSent == null)
                                toBeSent = true;
                            else
                                toBeSent = false;

                            break;
                        //Daily
                        case "2":
                            // if mail has not been sent on the day then send it now.
                            if (mail.LastSent == null)
                                toBeSent = true;
                            else if (mail.LastSent.Value.Subtract(date).Days <= -1)
                                toBeSent = true;
                            else
                                toBeSent = false;
                            break;
                        //Weekly
                        case "3":
                            // if no day has been selected then dont send the email
                            if (string.IsNullOrEmpty(schedule.DaysOfWeekToRun))
                                toBeSent = false;
                            else if (mail.LastSent == null) // if not be sent before then validate if its the right day of the week;
                            {
                                if (schedule.DaysOfWeekToRun.Contains(Convert.ToString(((int)date.DayOfWeek))))
                                {
                                    toBeSent = true;
                                }
                                else
                                    toBeSent = false;
                            }
                            else
                            {
                                // Validate the logic that mails need to be sent weekly on specific days
                                System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
                                int lastWeek = calendar.GetWeekOfYear(mail.LastSent.Value, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                                int currentWeek = calendar.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                                // confirms that email has not been already sent
                                if (lastWeek <= currentWeek)
                                {
                                    if (schedule.DaysOfWeekToRun.Contains(Convert.ToString(((int)date.DayOfWeek))))
                                    {
                                        toBeSent = true;
                                    }
                                    else
                                        toBeSent = false;
                                }// if mail has already been sent on that day of current  week then validate the different days to send it again
                                else if (lastWeek == currentWeek && mail.LastSent.Value.DayOfWeek < date.DayOfWeek)
                                {
                                    if (schedule.DaysOfWeekToRun.Contains(Convert.ToString(((int)date.DayOfWeek))))
                                    {
                                        toBeSent = true;
                                    }
                                    else
                                        toBeSent = false;
                                }
                            }
                            break;
                        //Monthly
                        case "4":
                            if (mail.LastSent == null)
                                toBeSent = true;
                            else if (mail.LastSent.Value.Month.CompareTo(date.Month) <= -1)
                            {
                                if (mail.LastSent.Value.Day == date.Day)
                                {
                                    toBeSent = true;
                                }
                                else
                                    toBeSent = false;
                            }
                            else
                                toBeSent = false;
                            break;
                        //yearly
                        case "5":
                            // if not be sent before then prepare to send;
                            if (mail.LastSent == null)
                                toBeSent = true;
                            else if (mail.LastSent.Value.Month.CompareTo(date.Year) <= -1)
                            {
                                if (mail.LastSent.Value.Day == date.Day)
                                {
                                    toBeSent = true;
                                }
                                else
                                    toBeSent = false;
                            }
                            else
                                toBeSent = false;
                            break;

                    }
                }
                if (toBeSent)
                    listOfMailsToBeSent.Add(mail);
            }
            return listOfMailsToBeSent;
        }

        /// <summary>
        /// Gets the week rows.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns>returns the number of month in that year</returns>
        public int GetWeekRows(int year, int month)
        {
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime lastDayOfMonth = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            int lastWeek = calendar.GetWeekOfYear(lastDayOfMonth, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int firstWeek = calendar.GetWeekOfYear(firstDayOfMonth, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return lastWeek - firstWeek + 1;
        }

        /// <summary>
        /// Sends the emails.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        void IMailUnitOfWork.SendEmails(string url, string userName, string password)
        {
            List<Mail> listOfMails = EmailsToBeSent();
            Email email = null;
            EmailUnitOfWork emailUnitOfWork = new EmailUnitOfWork();
            foreach (Mail mail in listOfMails)
            {

                mail.URL = "http://localhost:1840/user/list";
                //Example of api and parser collaboration, this should be moved to service class(ISchedularService) or similar in the core project
                var api = ServiceLocator.Resolve<IUserService>();
                var users = api.GetUsers(mail.URL, "user", "password");
                var template = @"<var  user = ""(ScheduMail.API.Contracts.User)Data""/>
            <var  promotion = ""(from p in user.Data.Elements('promotion')
                                select new {
                                  Product = (string)p.Element('product'),
                                  Discount = (string)p.Element('discount'),
                                  Expires = (string)p.Element('expires')
                                }).FirstOrDefault()""/>
            Dear !{user.FirstName},

            We are excited to tell you about our latest offerings.  Due to your long standing account with us we would 
            like to give you a sneak peak at our latest product before commercial release. The !{promotion.Product} is the
            best thing since slice bread and for a limited time only we would like to extend you a discount of !{promotion.Discount}.

            Act soon because the offer is only good until !{promotion.Expires}.

            Happy Buying!

            Click <a href='http://somecompany.com/unsubscribe?user=!{user.EmailAddress}'>here</a> to unsubscribe from out mailings.
          ";
                var parser = ServiceLocator.Resolve<ITemplateParser>();

                foreach (var user in users)
                {
                    email = new Email();
                    email.Body = parser.Render(user, "emailTemplate", template);
                    email.To = user.EmailAddress;
                    email.Subject = "";
                    email.From = "";
                    
                    email.FireAndForget = true;
                    emailUnitOfWork.SendMail(email);
                    Console.Write(email);
                    Console.WriteLine();
                }

            }

        }

        #endregion
    }
}
