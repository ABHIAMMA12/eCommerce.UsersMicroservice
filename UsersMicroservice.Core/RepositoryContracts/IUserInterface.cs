using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersMicroservice.Core.Entities;

namespace UsersMicroservice.Core.RepositoryContracts
{
    public interface IUserInterface
    {
        /// <summary>
        /// Method to add a User and return the added user data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        /// <summary>
        /// method to retrieve the existing user by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUserByEmailandPassword(string email, string password);
    }
}
