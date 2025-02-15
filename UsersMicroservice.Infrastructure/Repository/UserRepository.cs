using Dapper;
using UsersMicroservice.Core.Entities;
using UsersMicroservice.Core.RepositoryContracts;
using UsersMicroservice.Infrastructure.DbContext;

namespace UsersMicroservice.Infrastructure.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly DapperDbContext _dbContext;

        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            string query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
            int rowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
            if (rowsAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailandPassword(string email, string password)
        {
            string sqlQuery = "Select * from public.\"Users\" where \"Email\" = @Email and \"Password\" = @Password";
            var passingParameters = new { Email = email, Password = password };
            //QuerAsync returns IEnumerebale<Yourclass>
            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(sqlQuery, passingParameters);
            return user;
        }
    }
}
