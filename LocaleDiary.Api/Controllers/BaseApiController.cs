using System.Net.Http;
using System.Web.Http;
using LocaleDiary.Api.Infrastructure;
using LocaleDiary.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LocaleDiary.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        private ModelFactory _modelFactory;
        private readonly ApplicationUserManager _appUserManager;

        protected ApplicationUserManager AppUserManager
        {
            get { return _appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        public BaseApiController()
        {
            
        }

        protected ModelFactory TheModelFactory
        {
            get { return _modelFactory ?? (_modelFactory = new ModelFactory(Request, AppUserManager)); }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
