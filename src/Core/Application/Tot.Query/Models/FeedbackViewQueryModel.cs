using Tot.Shared.Queries;

namespace Tot.Query.Models
{
    public class FeedbackViewQueryModel : IQueryModel
    {
        public FeedbackViewQueryModel(string description, int groupId)
        {
            Description = description;
            GroupId = groupId;
        }

        public string Description { get; }
        public int GroupId { get; }
    }
}