
namespace BankApp.MVVM
{
    public class UserViewModel : BaseViewModel, IUserPersonalInformation
    {
        public string FirstName => UserModel.FirstName;
        public string LastName => UserModel.LastName;
        public string FullName => $"{FirstName} {LastName}";
        public int Age
        {
            get => UserModel?.Age ?? 0;
            set
            {
                UserModel.SetAge(value);
                Emit_PropertyChanged(nameof(Age));
            }
        }
        public UserModel UserModel { get; }

        public UserViewModel(UserModel userModel)
        {
            UserModel = userModel;
            UpdateProperties();
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        private void UpdateProperties()
        {
            Emit_PropertyChanged(nameof(FirstName));
            Emit_PropertyChanged(nameof(LastName));
            Emit_PropertyChanged(nameof(Age));
        }
    }
}
