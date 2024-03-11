using Microsoft.Extensions.DependencyInjection;

namespace BankApp.MVVM
{
    public class MainModel : BaseModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserRepository _userRepository;

        public IList<UserModel> UserModelList { get; set; }
        public MainModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _userRepository = _serviceProvider.GetRequiredService<IUserRepository>();

            UserModelList = new List<UserModel>();
        }

        internal async Task LoadUsers()
        {
            var users = await _userRepository.GetUsers();
            UserModelList = users.Select(x => new UserModel(CreateUserMetadata(x), x.Age)).ToList();
        }

        private UserMetadata CreateUserMetadata(UserData data)
        {
            return new UserMetadata(data.FirstName, data.LastName, data.Id);
        }
    }
}
