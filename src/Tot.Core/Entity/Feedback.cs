using System;
using Tot.Core.Interfaces;

namespace Tot.Core.Entity
{
    public class Feedback : IEntity<Guid>
    {
        protected Feedback()
        {
            // EF
        }

        private Feedback(string description, int groupId)
        {
            Id = Guid.NewGuid();
            Description = description;
            GroupId = groupId;
            Creation = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public int GroupId { get; private set; }
        public DateTime Creation { get; private set; }

        //EF HasOne Relationship
        public Group Group { get; private set; }
        public static Feedback CreateNewFeedback(string description, int groupId) => new Feedback(description, groupId);
    }
}
