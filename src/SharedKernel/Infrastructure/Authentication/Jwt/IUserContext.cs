namespace SharedKernel.Infrastructure.Authentication.Jwt;

public interface IUserContext
{
    Guid GetUserId();
}
