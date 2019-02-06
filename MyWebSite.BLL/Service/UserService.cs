
using MyWebSite.DAL.MyEntities;
using MyWebSite.DAL.Repositories.Concretes;

namespace MyWebSite.BLL.Service
{
    public class UserService
    {
        UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public int AddUser(User item)
        {
            return _userRepository.AddItem(item);
        }
        public int UpdateUser(User item)
        {
            return _userRepository.UpdateItem(item);
        }

    }
}
