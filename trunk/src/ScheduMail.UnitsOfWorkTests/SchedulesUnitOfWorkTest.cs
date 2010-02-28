using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Moq;
using NUnit.Framework;
using ScheduMail.Core.Domain;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.UnitsOfWork;

namespace ScheduMail.UnitsOfWorkTests
{
    /// <summary>
    /// Web site unit of work unit tests.
    /// </summary>
    [TestFixture]
    public class SchedulesUnitOfWorkTest
    {
        /// <summary>
        /// Webs the site_ container test.
        /// </summary>
        [Test]
        public void Schedule_ContainerTest()
        {
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter());

            IScheduleRepository repository;
                        
            // generic default service retrieval
            repository = container.Resolve<IScheduleRepository>();
            Assert.IsNotNull(repository);
            //// repository.Save(new ScheduMail.Core.Domain.Schedule());

            // service retreival only by given id
            repository = (IScheduleRepository)container.Resolve("ScheduleRepositoryService");
            Assert.IsNotNull(repository);
        }

        /// <summary >
        /// Webs the Schedule_ create test.
        /// </summary>
        [Test]
        public void Schedule_CreateTest()
        {
            var scheduleRepositoryMock = new Mock<IScheduleRepository>();
            var scheduleMock = new Mock<Schedule>();
            scheduleMock.Object.Id = 1;
            scheduleMock.Object.DailyWeeklyOrMonthly = "1";
            scheduleMock.Object.DaysOfWeekToRun = "1,2,3,4";
            scheduleMock.Object.StartDateTime = DateTime.Now;
            scheduleMock.Object.EndDateTime = DateTime.Now.AddYears(1);
            
            scheduleRepositoryMock.Setup(repository => repository.Save(scheduleMock.Object))
                .Returns(scheduleMock.Object);

            ScheduleUnitOfWork uow = new ScheduleUnitOfWork(scheduleRepositoryMock.Object);
            Schedule schedule = uow.Save(scheduleMock.Object);

            scheduleRepositoryMock.Verify(repository => repository.Save(scheduleMock.Object), Times.Exactly(1));
            Assert.IsTrue(schedule == scheduleMock.Object);
        }

        /// <summary>
        /// Webs the Schedule_ delete test.
        /// </summary>
        [Test]
        public void Schedule_DeleteTest()
        {
            var scheduleRepositoryMock = new Mock<IScheduleRepository>();
            var scheduleMock = new Mock<Schedule>();
            scheduleMock.Object.Id = 1;
            scheduleMock.Object.Id = 1;
            scheduleMock.Object.DailyWeeklyOrMonthly = "1";
            scheduleMock.Object.DaysOfWeekToRun = "1,2,3,4";
            scheduleMock.Object.StartDateTime = DateTime.Now;
            scheduleMock.Object.EndDateTime = DateTime.Now.AddYears(1);

            scheduleRepositoryMock.Setup(repository => repository.Delete(scheduleMock.Object));

            ScheduleUnitOfWork unitOfWork = new ScheduleUnitOfWork(scheduleRepositoryMock.Object);
            unitOfWork.Delete(scheduleMock.Object);

            scheduleRepositoryMock.Verify(repository => repository.Delete(scheduleMock.Object), Times.Exactly(1));
        }

        /// <summary>
        /// Webs the Schedule_GetById()
        /// </summary>
        [Test]
        public void Schedule_GetById()
        {
            var scheduleRepositoryMock = new Mock<IScheduleRepository>();
            var scheduleMock = new Mock<Schedule>();
            scheduleMock.Object.Id = 0;
            scheduleMock.Object.DailyWeeklyOrMonthly = "1";
            scheduleMock.Object.DaysOfWeekToRun = "1,2,3,4";
            scheduleMock.Object.StartDateTime = DateTime.Now;
            scheduleMock.Object.EndDateTime = DateTime.Now.AddYears(1);

            scheduleRepositoryMock.Setup(repository => repository.GetById(It.Is<long>(id => id > 0 && id < 6)))
                    .Returns(scheduleMock.Object);

            ScheduleUnitOfWork unitOfWork = new ScheduleUnitOfWork(scheduleRepositoryMock.Object);
            for (long i = 1; i <= 2; i++)
            {
                unitOfWork.GetById(i);
            }

            scheduleRepositoryMock.Verify(repository => repository.GetById(It.Is<long>(id => id > 0 && id < 6)), Times.Exactly(2));
        }

        /// <summary>
        /// Webs the Schedule_List
        /// </summary>
        [Test]
        public void Schedule_List()
        {
            var scheduleRepositoryMock = new Mock<IScheduleRepository>();
            List<Schedule> schedules = new List<Schedule>();

            scheduleRepositoryMock.Setup(repository => repository.List)
                    .Returns(schedules.AsQueryable());

            ScheduleUnitOfWork unitOfWork = new ScheduleUnitOfWork(scheduleRepositoryMock.Object);
            List<Schedule> scheduleList = unitOfWork.List;

            scheduleRepositoryMock.Verify(repository => repository.List, Times.AtLeastOnce());
            Assert.True(scheduleList.Count == 0);
        }       
    }
}
