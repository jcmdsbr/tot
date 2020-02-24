using Tot.Shared.Queries;

namespace Tot.Query.Models
{
    public class GroupViewQueryModel : IQueryModel
    {
        public GroupViewQueryModel(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }
        public string Description { get; }
    }
}