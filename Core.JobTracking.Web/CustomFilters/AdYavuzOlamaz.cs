using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.JobTracking.Web.CustomFilters
{
    public class AdYavuzOlamaz:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionaryGelen = context.ActionArguments.Where(I => I.Key == "model").FirstOrDefault();
            var model = dictionaryGelen.Value;
            base.OnActionExecuting(context);
            //if (model.Ad.ToLower() == "yavuz")
            //{
            //    context.Result = new RedirectResult("\\Home\\Error");
            //}
        }
    }
}
