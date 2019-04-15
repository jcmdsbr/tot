using System;
using Tot.Query.Models;

namespace Tot.Query.Queries.Feedbacks
{
    public class GetFeedbackByIdQuery : IQuery<FeedbackViewQueryModel>
    {
        public GetFeedbackByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}