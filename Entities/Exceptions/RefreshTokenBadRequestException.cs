namespace Entities.Exceptions
{
    public class RefreshTokenBadRequestException : BadRequestException

    {
        public RefreshTokenBadRequestException() : base($"Invalid client requet. The tokenDto has some invalid valuse.")
        {
        }
    }
}
