using Virtual_Interview_Platform.Model;

namespace Virtual_Interview_Platform.Services.Interface
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task DeleteUser(int userId);
        Task UpdateUser(User user);
        Task<User> GetUserById(int userId);
        Task<List<User>> GetAllUsers();


    }
}
