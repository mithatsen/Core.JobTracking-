using AutoMapper;
using Core.JobTracking.DTO.DTOs.AppUserDtos;
using Core.JobTracking.DTO.DTOs.NotificationDtos;
using Core.JobTracking.DTO.DTOs.PriorityDtos;
using Core.JobTracking.DTO.DTOs.WorkDtos;
using Core.JobTracking.DTO.DTOs.ReportDtos;
using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.Mapping.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region AppUser-AppUseDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();

            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserListDto, AppUser>();

            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();

            CreateMap<AppUser, AppUserUpdateDto>();
            CreateMap<AppUserUpdateDto, AppUser>();
            #endregion

            #region Notification-NotificationListDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Priority-priorityDto
            CreateMap<PriorityAddDto, Priority>();
            CreateMap<Priority, PriorityAddDto>();

            CreateMap<PriorityUpdateDto, Priority>();
            CreateMap<Priority, PriorityUpdateDto>();

            CreateMap<PriorityListDto, Priority>();
            CreateMap<Priority, PriorityListDto>();
            #endregion

            #region Work-WorkDto
            CreateMap<WorkAddDto, Work>();
            CreateMap<Work, WorkAddDto>();

            CreateMap<WorkListDto, Work>();
            CreateMap<Work, WorkListDto>();

            CreateMap<WorkUpdateDto, Work>();
            CreateMap<Work, WorkUpdateDto>();

            CreateMap<WorkListWithAllTableDto, Work>();
            CreateMap<Work, WorkListWithAllTableDto>();
            #endregion

            #region Report-ReportAddDto
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();

            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>(); 

            CreateMap<Report, ReportFileDto>(); 
            CreateMap<ReportFileDto, Report>(); 
            #endregion
        }
    }
}
