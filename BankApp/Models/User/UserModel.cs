namespace BankApp.MVVM
{
    public class UserModel : BaseModel, IUserModel
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Money { get; private set; }
        public int Age 
        {
            get => _age;
            private set
            {
                _age = value;
                Emit_PropertyChanged(nameof(Age));
            } 
        }

        public Guid Id { get; init; }

        public UserModel(UserMetadata userMetadata)
        {
            FirstName = userMetadata.FirstName;
            LastName = userMetadata.LastName;
            Id = userMetadata.Id ?? Guid.NewGuid();
        }

        public UserModel(UserMetadata userMetadata, int age) : this(userMetadata)
        {
            Age = age;
            //server.OnMoneyReceived += Server_OnMoneyReceived;
        }

        private void Server_OnMoneyReceived(object? sender, int moneyAmount)
        {
            Money += moneyAmount;
        }

        public void SetAge(int age)
        {
            Age = age;
        }
    }

    public readonly record struct UserMetadata(string FirstName, string LastName, Guid? Id = null);
}
