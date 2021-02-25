namespace CarRental.Common.Interfaces
{
    public interface IPerson
    {
        int Id { get; }
        string SocialSecurityNumber { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
