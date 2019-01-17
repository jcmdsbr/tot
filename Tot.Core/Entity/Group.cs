using System.Collections.Generic;
using Tot.Core.Interfaces;

namespace Tot.Core.Entity
{
    public class Group : IEntity<int>
    {
        protected Group() { }

        public int Id { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyCollection<Role> Roles { get; private set; }
    }
}
