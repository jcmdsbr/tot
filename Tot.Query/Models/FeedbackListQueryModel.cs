using System.Collections;
using System.Collections.Generic;

namespace Tot.Query.Models
{
    public class FeedbackListQueryModel : IEnumerable<FeedbackViewQueryModel>, IQueryModel
    {
        private readonly List<FeedbackViewQueryModel> _feedbacks;

        public FeedbackListQueryModel(List<FeedbackViewQueryModel> feedbacks)
        {
            _feedbacks = feedbacks;
        }

        public IEnumerator<FeedbackViewQueryModel> GetEnumerator()
        {
            return _feedbacks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _feedbacks.GetEnumerator();
        }
    }
}