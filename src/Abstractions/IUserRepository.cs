using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Abstractions
{
    public interface IUserRepository
    {
        public IEnumerable<User> FindMany();
        public User CreateOne(User user);
        public User? FindOneByEmail(string email);
        public User UpdateOne(User updatedUser);
        public User DeleteOne(Guid userId);
        public User FindOneById(Guid userId);
    }
}
