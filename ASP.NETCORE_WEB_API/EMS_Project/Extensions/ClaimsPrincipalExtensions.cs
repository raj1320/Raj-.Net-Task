using System.Security.Claims;

namespace EMS_Project.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            if (user?.Identity?.IsAuthenticated != true)
                throw new UnauthorizedAccessException("User is not authenticated.");

            var claim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                throw new UnauthorizedAccessException("User ID claim not found.");

            if (!int.TryParse(claim.Value, out var userId))
                throw new UnauthorizedAccessException("Invalid User ID.");

            return userId;
        }

    }
}
