namespace BankApp.MVVM
{
    internal interface IUserModel : IUserPersonalInformation
    {
        Guid Id { get; }
    }

    internal interface IUserPersonalInformation
    {
        string FirstName { get; }
        string LastName { get; }
        int Age { get; }
    }
}
