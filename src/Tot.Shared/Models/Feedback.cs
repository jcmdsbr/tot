using System;

namespace Tot.Shared.Models
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

        public string Description { get; }
        public int GroupId { get; }
        public DateTime Creation { get; }

        //EF HasOne Relationship
        public Group Group { get; private set; }

        public Guid Id { get; }

        public static Feedback CreateNewFeedback(string description, int groupId)
        {
            return new Feedback(description, groupId);
        }
    }
}