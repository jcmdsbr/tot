using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tot.Api.Models;
using Tot.Infra.Bus;
using Tot.Query.Queries.Groups;

namespace Tot.Api.Controllers
{
    [Route("api/groups")]
    public class GroupController : BaseApiController
    {
        public GroupController(IMediatorHandler bus) : base(bus)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetGroupViewResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IReadOnlyCollection<GetGroupViewResponse>> List()
        {
            GetGroupListQuery query = new GetGroupListQuery();

            var result = await Bus.ExecuteQuery(query);

            return result.Select(x => new GetGroupViewResponse(x.Id, x.Description)).ToList();
        }
    }
}