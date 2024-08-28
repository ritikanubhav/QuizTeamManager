namespace QuizTeam.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        //adding own custom error prop for debugging
        public string? Message { get; set; }
        public Exception? exception { get; set; }
        public bool ShowException {  get; set; }

    }
}
