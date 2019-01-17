namespace Tot.Api.Models
{
    public class CreateFeedbackResponse
    {
        public CreateFeedbackResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}