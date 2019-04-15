using System.Collections.Generic;
using Tot.Core.Interfaces;

namespace Tot.Core.Entity
{
    public class Collaborator : IEntity<int>
    {
        protected Collaborator() { }

        public int Id { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyCollection<Role> Roles { get; private set; }
    }
}
