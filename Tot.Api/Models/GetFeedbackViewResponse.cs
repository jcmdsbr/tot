namespace Tot.Api.Models
{
    public class GetFeedbackViewResponse
    {
        public GetFeedbackViewResponse(string description, int groupId)
        {
            Description = description;
            GroupId = groupId;
        }

        public string Description { get; set; }
        public int GroupId { get; set; }
    }
}