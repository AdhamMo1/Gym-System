namespace GymApi.Exceptions
{
    public class NotAuthorizedAccessException : Exception
    {
        public NotAuthorizedAccessException(string msg):base(msg) {
        }
    }
}
