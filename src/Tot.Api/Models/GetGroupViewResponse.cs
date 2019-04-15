namespace Tot.Api.Models
{
    public class GetGroupViewResponse
    {
        public GetGroupViewResponse(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}