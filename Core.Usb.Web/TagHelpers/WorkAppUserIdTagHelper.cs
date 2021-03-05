using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.Entities.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Usb.Web.TagHelpers
{
    [HtmlTargetElement("GetWorkWithAppUserId")]
    public class WorkAppUserIdTagHelper : TagHelper
    {
        private readonly IWorkingService _workingService;
        public WorkAppUserIdTagHelper(IWorkingService workingService)
        {
            _workingService = workingService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Work> works= _workingService.GetWorksWithAppUserId(AppUserId);

            int finished = works.Where(p => p.Status == true).Count();
            int notFinished = works.Where(p => p.Status == false).Count();

            string htmlString = $"<div class='shadow p-3'> <strong style='color: red'> Tamamladığı görev sayısı : {finished} </strong>  <br /> <strong style='color:green'> Şu anda devam ettiği iş sayısı: {notFinished} </strong>  </div> ";

            output.Content.SetHtmlContent(htmlString);

            base.Process(context, output);
        }
    }
}


//bunu yazınca view importa yüklenmeli