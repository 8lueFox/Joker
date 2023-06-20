namespace Joker.Identity.Core.Entities;

public static class Role
{
    public const string User = "user";
    public const string Admin = "admin";

    public static bool IsValid(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
            return false;

        roleName = roleName.ToLowerInvariant();

        return roleName == User || roleName == Admin;
    }
}
