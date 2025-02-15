using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersMicroservice.Core.DTO;

namespace UsersMicroservice.Core.ServiceContracts
{
    /// <summary>
    /// contract for users service that contains    use cases for users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// method to handle login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        /// <summary>
        /// method to handle register and its use cases
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
