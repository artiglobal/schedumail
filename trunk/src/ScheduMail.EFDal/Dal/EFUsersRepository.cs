using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.DBModel;

namespace ScheduMail.EFDal.Dal
{
    public class EFUsersRepository : IUserRepository
    {
        private ScheduMailDBEntities context = new ScheduMailDBEntities();     

        #region Ctors

        public EFUsersRepository(string connectionString)
        {
           
        }

        #endregion

        #region ICrudRepository<User,int> Members

        public IQueryable<ScheduMail.DBModel.User> List
        {
            get { return context.Users.AsQueryable(); }
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
