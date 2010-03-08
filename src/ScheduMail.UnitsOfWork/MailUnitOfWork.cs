using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.Core.Domain;
using System;

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
            List<ScheduMail.Core.Domain.Schedule> scheduleList = scheduleUnitOfWork.GetListOfSchedule(true);

            Mail mail = null;
            //get list of all mails 

            List<Mail> listOfMails = this.List.ToList();
            List<Mail> listOfMailsToBeSent = new List<Mail>();
            DateTime date = DateTime.Now;

            bool toBeSent = false;

            foreach (Schedule schedule in scheduleList)
            {
                //rset the value
                toBeSent = false;

                if (schedule.EndDateTime == null)
                    toBeSent = true;
                else
                {
                    //validate mails are not expired
                    if (schedule.StartDateTime <= date && schedule.EndDateTime >= date)
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
                    if (mail.LastSent == null)
                    {
                        switch (schedule.DailyWeeklyOrMonthly)
                        {
                            // Single
                            case "1":
                                toBeSent = true;
                                break;
                            //Daily
                            case "2":
                                toBeSent = true;
                                break;
                            //Weekly
                            case "3":
                                // if not be sent before then vlaidaet if its the right day of the week;
                                if (string.IsNullOrEmpty(schedule.DaysOfWeekToRun))
                                    toBeSent = true;
                                else if (schedule.DaysOfWeekToRun.Contains(Convert.ToString(((int)date.DayOfWeek))))
                                {
                                    toBeSent = true;
                                }
                                else
                                    toBeSent = false;
                                break;
                            //Monthly
                            case "4":
                                toBeSent = true;
                                break;
                            //yearly
                            case "5":
                                // if not be sent before then prepare to send;
                                toBeSent = true;
                                break;

                        }
                    }
                    else
                    {
                        switch (schedule.DailyWeeklyOrMonthly)
                        {
                            // Single
                            case "1":
                                toBeSent = false;
                                break;
                            //Daily
                            case "2":
                                if (mail.LastSent.Value.Subtract(date).Days >= 1)
                                    toBeSent = true;
                                else
                                    toBeSent = false;
                                break;
                            //Weekly
                            case "3":
                                // if not be sent before then vlaidaet if its the right day of the week;
                                System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
                                int lastWeek = calendar.GetWeekOfYear(mail.LastSent.Value, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                                int currentWeek = calendar.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                                if (lastWeek <= currentWeek )
                                {
                                    if (string.IsNullOrEmpty(schedule.DaysOfWeekToRun))
                                        toBeSent = true;
                                    else if (schedule.DaysOfWeekToRun.Contains(Convert.ToString(((int)date.DayOfWeek))))
                                    {
                                        toBeSent = true;
                                    }
                                    else
                                        toBeSent = false;
                                }
                                else if (lastWeek == currentWeek && mail.LastSent.Value.DayOfWeek  < date.DayOfWeek)
                                {
                                    if (string.IsNullOrEmpty(schedule.DaysOfWeekToRun))
                                        toBeSent = true;
                                    else if (schedule.DaysOfWeekToRun.Contains(Convert.ToString(((int)date.DayOfWeek))))
                                    {
                                        toBeSent = true;
                                    }
                                    else
                                        toBeSent = false;
                                }

                                break;
                            //Monthly
                            case "4":
                                if (mail.LastSent.Value.Month.CompareTo(date.Month) <= -1)
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
                                if (mail.LastSent.Value.Month.CompareTo(date.Year) <= -1)
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
            }

            //return this.repository.(schedule);


            return listOfMailsToBeSent;

            //return errors;
        }

        public int GetWeekRows(int year, int month)
        {
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime lastDayOfMonth = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            int lastWeek = calendar.GetWeekOfYear(lastDayOfMonth, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int firstWeek = calendar.GetWeekOfYear(firstDayOfMonth, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return lastWeek - firstWeek + 1;
        }
        //public decimal RowsForMonth(int month, int year)
        //{
        //    DateTime first = new DateTime(year, month, 1);

        //    //number of days pushed beyond monday this one sits
        //    int offset = ((int)first.DayOfWeek) - 1;

        //    int actualdays = DateTime.DaysInMonth(month, year) + offset;

        //    decimal rows = (actualdays / 7);
        //    if ((rows - ((decimal)rows)) > .1)
        //    {
        //        rows++;
        //    }
        //    return rows;
        //}





        #endregion
    }
}
