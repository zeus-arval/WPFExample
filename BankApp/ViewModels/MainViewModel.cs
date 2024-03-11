using Microsoft.Extensions.DependencyInjection;
using MoreLinq;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BankApp.MVVM
{
    public class MainViewModel : BaseViewModel
    {
        public MainModel MainModel { get; private set; }
        public ObservableCollection<UserViewModel> Users { get; private set; }

        public MainViewModel(IServiceProvider serviceProvider)
        {
            Users = new ObservableCollection<UserViewModel>();
            MainModel = CreateMainModel(serviceProvider);
        }

        private MainModel CreateMainModel(IServiceProvider serviceProvider)
        {
            return new MainModel(serviceProvider);
        }

        private UserViewModel CreateUserViewModel(UserModel user)
        {
            return new UserViewModel(user);
        }

        //internal void SetAge(int age)
        //{
        //    UserViewModel.SetAge(age);
        //}

        internal async Task LoadUsers()
        {
            await MainModel.LoadUsers();
            Users.Clear();
            MainModel.UserModelList.Select(CreateUserViewModel).ForEach(x => Users.Add(x));
        }
    }
}
