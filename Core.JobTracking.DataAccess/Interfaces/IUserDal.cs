using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DataAccess.Interfaces
{
    public interface IUserDal 
    {
        List<AppUser> GetNotAdmin(); //ilk entity içine türünü oluştur, sonra ıuserdal oluştur sonra repository oluştur
        List<AppUser> GetNotAdmin(out int totalPages ,string searchWord, int size, int activePage = 1);

        List<DualHelper> GetTop5MostCompletedWorkAppUsers();
        List<DualHelper> GetTop5MostCompletedWorkNowAppUsers();

     
    }
}
