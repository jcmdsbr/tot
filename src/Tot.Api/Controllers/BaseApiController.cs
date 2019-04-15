using Microsoft.AspNetCore.Mvc;
using Tot.Infra.Bus;

namespace Tot.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IMediatorHandler Bus;

        protected BaseApiController(IMediatorHandler bus)
        {
            Bus = bus;
        }
    }
}