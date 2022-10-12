namespace Temp.Common.Infrastructure
{
    /// <summary>
    /// role enum
    /// </summary>
    public enum Roles
    {
        Admin = 1,
        User = 2
    }

    /// <summary>
    /// user type for check request expired date
    /// </summary>
    public enum UserType
    {
        None = 0,
        Processing = 1,
        Reject = 2,
        Approve = 3
    }
}
