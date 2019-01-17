namespace Tot.Command.Commands
{
    public class CreateFeedbackCommand : ICommand<CreateFeedbackCommandResult>
    {
        public CreateFeedbackCommand(string description, int groupId)
        {
            Description = description;
            GroupId = groupId;
        }

        public string Description { get; }
        public int GroupId { get; }
    }
}