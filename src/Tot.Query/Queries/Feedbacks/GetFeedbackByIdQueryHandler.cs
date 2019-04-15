using System.Threading;
using System.Threading.Tasks;
using Tot.Core.Entity;
using Tot.Query.Models;

namespace Tot.Query.Queries.Feedbacks
{
    public class GetFeedbackByIdQueryHandler : IQueryHandler<GetFeedbackByIdQuery, FeedbackViewQueryModel>
    {
        private readonly IReadOnlyRepository<Feedback> _readOnlyRepository;

        public GetFeedbackByIdQueryHandler(IReadOnlyRepository<Feedback> readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<FeedbackViewQueryModel> Handle(GetFeedbackByIdQuery request,
            CancellationToken cancellationToken)
        {
            //Todo add cache control

            var feedback = await _readOnlyRepository.FindById(request.Id);

            return new FeedbackViewQueryModel(feedback.Description, feedback.GroupId);
        }
    }
}