using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tot.Core.Entity;
using Tot.Query.Models;

namespace Tot.Query.Queries.Feedbacks
{
    public class GetFeedbackListQueryHandler : IQueryHandler<GetFeedbackListQuery, FeedbackListQueryModel>
    {
        private readonly IReadOnlyRepository<Feedback> _readOnlyRepository;

        public GetFeedbackListQueryHandler(IReadOnlyRepository<Feedback> readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<FeedbackListQueryModel> Handle(GetFeedbackListQuery request,
            CancellationToken cancellationToken)
        {
            //Todo add cache control

            var feedbacks = await _readOnlyRepository.List();

            var views = feedbacks.Select(x => new FeedbackViewQueryModel(x.Description, x.GroupId)).ToList();

            return new FeedbackListQueryModel(views);
        }
    }
}