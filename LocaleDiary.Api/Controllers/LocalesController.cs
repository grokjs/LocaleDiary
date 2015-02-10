using System;
using System.Threading.Tasks;
using System.Web.Http;
using LocaleDiary.Services;

namespace LocaleDiary.Api.Controllers
{
    [RoutePrefix("api/locales")]
    public class LocalesController : ApiController
    {
        private readonly LocaleService _localeService;

        public LocalesController(LocaleService localeService)
        {
            _localeService = localeService;
        }

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var locales = await _localeService.GetLocalesForUserAsync(
                new Guid("710443CA-DBEF-49C4-AF08-F8457B8D1EDD"));
            return Ok(locales);
        }
    }
}
