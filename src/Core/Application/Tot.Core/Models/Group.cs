using System.Collections.Generic;

namespace Tot.Shared.Models
{
    public class Group : IEntity<int>
    {
        protected Group()
        {
        }

        public string Description { get; private set; }

        public IReadOnlyCollection<Role> Roles { get; private set; }

        public int Id { get; private set; }
    }
}