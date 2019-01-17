namespace Tot.Command.Commands
{
    public class CreateFeedbackCommandResult : CommandResult
    {
        public CreateFeedbackCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public string Message { get; }
    }
}