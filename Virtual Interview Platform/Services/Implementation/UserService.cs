using Azure;
using Microsoft.EntityFrameworkCore;
using Virtual_Interview_Platform.Data;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;

namespace Virtual_Interview_Platform.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create user
        public async Task<int> CreateUser(User user)
        {
            try
            {
                // Check if user with the same full name or email exists
                var userExists = await _context.Users
                    .FirstOrDefaultAsync(u => u.FullName == user.FullName);

                if (userExists != null)
                {
                    throw new Exception("User with this name already exists.");
                }

                var emailExists = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == user.Email);

                if (emailExists != null)
                {
                    throw new Exception("User with this email already exists.");
                }

                // Add new user
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user.UserID;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating user: {ex.Message}");
            }
        }

        // Delete user
        public async Task DeleteUser(int userId)
        {
            try
            {
                var userExists = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserID == userId);

                if (userExists == null)
                {
                    throw new Exception("User does not exist.");
                }

                _context.Users.Remove(userExists);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting user: {ex.Message}");
            }
        }

        // Get all users
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving users: {ex.Message}");
            }
        }

        // Get user by ID
        public async Task<User> GetUserById(int userId)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserID == userId);

                if (user == null)
                {
                    throw new Exception("User with this ID does not exist.");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving user by ID: {ex.Message}");
            }
        }

        // Update user
        public async Task UpdateUser(User user)
        {
            try
            {
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserID == user.UserID);

                if (existingUser == null)
                {
                    throw new Exception("User with this ID does not exist.");
                }

                var nameExists = await _context.Users
                    .FirstOrDefaultAsync(u => u.FullName == user.FullName && u.UserID != user.UserID);

                if (nameExists != null)
                {
                    throw new Exception("User with this name already exists.");
                }

                var emailExists = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == user.Email && u.UserID != user.UserID);

                if (emailExists != null)
                {
                    throw new Exception("The email is already in use.");
                }

                // Update user details
                existingUser.FullName = user.FullName;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.CreatedAt = user.CreatedAt;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating user: {ex.Message}");
            }
        }
    }
}
