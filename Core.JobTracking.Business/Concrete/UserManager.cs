using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<AppUser> GetNotAdmin()
        {
            return _userDal.GetNotAdmin(); // bu işlem yetmez çünkü dependency injection için startupa ekleme yapmak lazım

        }

        public List<AppUser> GetNotAdmin(out int totalPages,string searchWord, int size, int activePage = 1)
        {
            return _userDal.GetNotAdmin(out totalPages,searchWord, size, activePage);
        }

        public List<DualHelper> GetTop5MostCompletedWorkAppUsers()
        {
            return _userDal.GetTop5MostCompletedWorkAppUsers();
        }

        public List<DualHelper> GetTop5MostCompletedWorkNowAppUsers()
        {
            return _userDal.GetTop5MostCompletedWorkNowAppUsers();
        }
    }
}
