namespace BusinessLogicLayer.Common
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<String> Errors { get; set; }
    }
}
