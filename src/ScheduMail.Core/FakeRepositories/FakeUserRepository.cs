using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.DBModel;

namespace ScheduMail.Core.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        #region ICrudRepository<User,int> Members

        private static IQueryable<User> FakeUsers = new List<User>
        {
            new User { Id = 0, FullName = "John Coxhead" },
            new User { Id = 1, FullName = "Jane Mansfield" },
            new User { Id = 2, FullName = "Jock Stein" },
            new User { Id = 3, FullName = "Lois Saha" }

        }.AsQueryable();

        public IQueryable<ScheduMail.DBModel.User> List
        {
            get { return FakeUsers; }
        }

        public ScheduMail.DBModel.User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ScheduMail.DBModel.User Save(ScheduMail.DBModel.User entity)
        {
            throw new NotImplementedException();
        }

        public ScheduMail.DBModel.User Update(ScheduMail.DBModel.User entity, ScheduMail.DBModel.User originalEntity)
        {
            throw new NotImplementedException();
        }

        public ScheduMail.DBModel.User Update(ScheduMail.DBModel.User entity, ScheduMail.DBModel.User originalEntity, bool attach)
        {
            throw new NotImplementedException();
        }

        public void Delete(ScheduMail.DBModel.User entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
