using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CleanArchitectureMVC.Common.ResultModel;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace CleanArchitectureMVC.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {
        protected object DetailedException(Exception ex)
        {
            var errorMessage = ex.Message;
            if(ex.InnerException != null)
            {
                errorMessage = "\n\nException" + GetInnerException(ex);
            }
            var result = new Result
            { 
                status = new Status
                {
                    code = (int)HttpStatusCode.InternalServerError,
                    message = errorMessage
                }
            };
            return result;
        }

        private string GetInnerException(Exception ex)
        {
            if(ex.InnerException != null)
            {
                return $"{ex.InnerException.Message + "(\n" + ex.Message + ")\n"} > {GetInnerException(ex.InnerException)}";
            }
            return string.Empty;
        }
    }
    
}
