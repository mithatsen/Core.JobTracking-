using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Interfaces
{
    public interface IUserService
    {
        List<AppUser> GetNotAdmin();
        List<AppUser> GetNotAdmin(out int totalPages, string searchWord, int size, int activePage = 1);

        List<DualHelper> GetTop5MostCompletedWorkAppUsers();
        List<DualHelper> GetTop5MostCompletedWorkNowAppUsers();

    }
}
