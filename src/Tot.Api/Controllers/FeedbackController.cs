using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tot.Api.Models;
using Tot.Command.Commands;
using Tot.Infra.Bus;
using Tot.Query.Queries.Feedbacks;

namespace Tot.Api.Controllers
{
    [Route("api/feedbacks")]
    public class FeedbackController : BaseApiController
    {
        public FeedbackController(IMediatorHandler bus) : base(bus)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetFeedbackViewResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IReadOnlyCollection<GetFeedbackViewResponse>> List()
        {
            var query = new GetFeedbackListQuery();

            var result = await Bus.ExecuteQuery(query);

            return result.Select(x => new GetFeedbackViewResponse(x.Description, x.GroupId)).ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetFeedbackViewResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<GetFeedbackViewResponse> GetById(Guid id)
        {
            var query = new GetFeedbackByIdQuery(id);

            var result = await Bus.ExecuteQuery(query);

            return new GetFeedbackViewResponse(result.Description, result.GroupId);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateFeedbackResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CreateFeedbackResponse>> Create(CreateFeedbackRequest request)
        {
            var command = new CreateFeedbackCommand(request.Description, request.GroupId);

            var cmdResult = await Bus.SendCommand(command);

            return new CreateFeedbackResponse(cmdResult.Success, cmdResult.Message);
        }
    }
}