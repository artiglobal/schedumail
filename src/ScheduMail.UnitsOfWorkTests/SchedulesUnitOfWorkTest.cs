using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Moq;
using NUnit.Framework;
using ScheduMail.Core.Domain;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.UnitsOfWork;
using System;

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
            var ScheduleRepositoryMock = new Mock<IScheduleRepository>();
            var ScheduleMock = new Mock<Schedule>();
            ScheduleMock.Object.Id = 1;
            ScheduleMock.Object.DailyWeeklyOrMonthly = "1";
            ScheduleMock.Object.DaysOfWeekToRun = "1,2,3,4";
            ScheduleMock.Object.StartDateTime = DateTime.Now;
            ScheduleMock.Object.EndDateTime = DateTime.Now.AddYears(1);
            

            ScheduleRepositoryMock.Setup(repository => repository.Save(ScheduleMock.Object))
                .Returns(ScheduleMock.Object);

            ScheduleUnitOfWork uow = new ScheduleUnitOfWork(ScheduleRepositoryMock.Object);
            Schedule Schedule = uow.Save(ScheduleMock.Object);

            ScheduleRepositoryMock.Verify(repository => repository.Save(ScheduleMock.Object), Times.Exactly(1));
            Assert.IsTrue(Schedule == ScheduleMock.Object);
        }

        /// <summary>
        /// Webs the Schedule_ delete test.
        /// </summary>
        [Test]
        public void Schedule_DeleteTest()
        {
            var ScheduleRepositoryMock = new Mock<IScheduleRepository>();
            var ScheduleMock = new Mock<Schedule>();
            ScheduleMock.Object.Id = 1;
            ScheduleMock.Object.Id = 1;
            ScheduleMock.Object.DailyWeeklyOrMonthly = "1";
            ScheduleMock.Object.DaysOfWeekToRun = "1,2,3,4";
            ScheduleMock.Object.StartDateTime = DateTime.Now;
            ScheduleMock.Object.EndDateTime = DateTime.Now.AddYears(1);

            ScheduleRepositoryMock.Setup(repository => repository.Delete(ScheduleMock.Object));

            ScheduleUnitOfWork unitOfWork = new ScheduleUnitOfWork(ScheduleRepositoryMock.Object);
            unitOfWork.Delete(ScheduleMock.Object);

            ScheduleRepositoryMock.Verify(repository => repository.Delete(ScheduleMock.Object), Times.Exactly(1));
        }

        /// <summary>
        /// Webs the Schedule_GetById()
        /// </summary>
        [Test]
        public void Schedule_GetById()
        {
            var ScheduleRepositoryMock = new Mock<IScheduleRepository>();
            var ScheduleMock = new Mock<Schedule>();
            ScheduleMock.Object.Id = 0;
            ScheduleMock.Object.DailyWeeklyOrMonthly = "1";
            ScheduleMock.Object.DaysOfWeekToRun = "1,2,3,4";
            ScheduleMock.Object.StartDateTime = DateTime.Now;
            ScheduleMock.Object.EndDateTime = DateTime.Now.AddYears(1);

            ScheduleRepositoryMock.Setup(repository => repository.GetById(It.Is<long>(id => id > 0 && id < 6)))
                    .Returns(ScheduleMock.Object);

            ScheduleUnitOfWork unitOfWork = new ScheduleUnitOfWork(ScheduleRepositoryMock.Object);
            for (long i = 1; i <= 2; i++)
            {
                unitOfWork.GetById(i);
            }

            ScheduleRepositoryMock.Verify(repository => repository.GetById(It.Is<long>(id => id > 0 && id < 6)), Times.Exactly(2));
        }

        /// <summary>
        /// Webs the Schedule_List
        /// </summary>
        [Test]
        public void Schedule_List()
        {
            var ScheduleRepositoryMock = new Mock<IScheduleRepository>();
            List<Schedule> Schedules = new List<Schedule>();

            ScheduleRepositoryMock.Setup(repository => repository.List)
                    .Returns(Schedules.AsQueryable());

            ScheduleUnitOfWork unitOfWork = new ScheduleUnitOfWork(ScheduleRepositoryMock.Object);
            List<Schedule> ScheduleList = unitOfWork.List;

            ScheduleRepositoryMock.Verify(repository => repository.List, Times.AtLeastOnce());
            Assert.True(ScheduleList.Count == 0);
        }

       
    }
}
