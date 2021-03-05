using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUserRepository : IUserDal  //  bu işlemden sonra businesa git ve interface oluştur
    {
        
        public List<AppUser> GetNotAdmin()
        {
            using (var context = new JobTrackingContext())
            {
                return context.UserRoles.Join(context.Users, userRoles => userRoles.UserId, users => users.Id, (resultUserRole, resultUser) => new
                {
                    userRole = resultUserRole,
                    user = resultUser
                }).Join
                 (context.Roles, userRoles => userRoles.userRole.RoleId, role => role.Id, (resultUserRole, resultRole) => new
                 {
                     user = resultUserRole.user,
                     userRole = resultUserRole.userRole,
                     roles = resultRole
                 }).Where(p => p.roles.Name == "Member").Select(p => new AppUser()
                 {
                     Id = p.user.Id,
                     Name = p.user.Name,
                     Surname = p.user.Surname,
                     UserName = p.user.UserName,
                     Email = p.user.Email,
                     Picture = p.user.Picture
                 }).ToList();
            }

        }
        public List<AppUser> GetNotAdmin(out int totalPages,string searchWord, int size, int activePage=1)
        {
            using var context = new JobTrackingContext();

            var result = context.UserRoles.Join(context.Users, userRoles => userRoles.UserId, users => users.Id, (resultUserRole, resultUser) => new
            {
                userRole = resultUserRole,
                user = resultUser
            }).Join
             (context.Roles, userRoles => userRoles.userRole.RoleId, role => role.Id, (resultUserRole, resultRole) => new
             {
                 user = resultUserRole.user,
                 userRole = resultUserRole.userRole,
                 roles = resultRole
             }).Where(p => p.roles.Name == "Member").Select(p => new AppUser()
             {
                 Id = p.user.Id,
                 Name = p.user.Name,
                 Surname = p.user.Surname,
                 UserName = p.user.UserName,
                 Email = p.user.Email,
                 Picture = p.user.Picture
             });
            totalPages = (int)Math.Ceiling((double)result.Count() / size);
            if (!string.IsNullOrWhiteSpace(searchWord))  //sayfada find işlemi işçüin gerekli
            {
                result=result.Where(I => I.Name.ToLower().Contains(searchWord.ToLower()) || I.Surname.ToLower().Contains(searchWord.ToLower()));
                totalPages = (int)Math.Ceiling((double)result.Count() / size);
            }
           

            result =result.Skip((activePage - 1) * size).Take(size);

            return result.ToList();

        }

        public List<DualHelper> GetTop5MostCompletedWorkAppUsers()
        {
            using var context = new JobTrackingContext();
            return context.Works.Include(p => p.AppUser).Where(p => p.Status).GroupBy(p => p.AppUser.UserName).OrderByDescending(p => p.Count()).Take(5).
                Select(p => new DualHelper
                {
                    Name = p.Key,
                    Number = p.Count()
                }).ToList();
        }
        public List<DualHelper> GetTop5MostCompletedWorkNowAppUsers()
        {
            using var context = new JobTrackingContext();
            return context.Works.Include(p => p.AppUser).Where(p => !p.Status && p.AppUserId!=null).GroupBy(p => p.AppUser.UserName).OrderByDescending(p => p.Count()).Take(5).
                Select(p => new DualHelper
                {
                    Name = p.Key,
                    Number = p.Count()
                }).ToList();
        }
    }

    
}

//Select AspNetUsers.Id,....,...,.,.,., from AspNetUserRoles
//inner join AspNetUsers on AspNetUserRoles.UserId=AspNetUsers.Id
//inner join AspNetRoles on AspNetUserRoles.RoleId=AspNetRoles.Id

//where AspNetRoles.Name='Member';


