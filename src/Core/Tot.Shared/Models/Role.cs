namespace Tot.Shared.Models
{
    public class Role : IEntity
    {
        protected Role()
        {
        }

        public int CollaboratorId { get; private set; }
        public int GroupId { get; private set; }

        public Collaborator Collaborator { get; private set; }
        public Group Group { get; private set; }
    }
}