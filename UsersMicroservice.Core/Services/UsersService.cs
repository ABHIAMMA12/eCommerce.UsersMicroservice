using AutoMapper;
using UsersMicroservice.Core.DTO;
using UsersMicroservice.Core.Entities;
using UsersMicroservice.Core.RepositoryContracts;
using UsersMicroservice.Core.ServiceContracts;

namespace UsersMicroservice.Core.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserInterface _userInterface;
        private readonly IMapper _mapper;
        public UsersService(IUserInterface userInterface, IMapper mapper)
        {
            _userInterface = userInterface;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userInterface.GetUserByEmailandPassword(loginRequest.Email!, loginRequest.Password!);
            if (user is null)
            {
                return null;
            }
            //return new AuthenticationResponse(user.UserId, user.Email, user.PersonName, user.Gender, "token",Success:true);  
            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            //create a new Applicationuser object from RegisterRequest
            //ApplicationUser user = new ApplicationUser()
            //{
            //    Gender = registerRequest.Gender.ToString(),
            //    PersonName = registerRequest.PersonName,
            //    Email = registerRequest.Email,
            //    Password = registerRequest.Password
            //};
            // in <> this dest class and in () src class will be there
            ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
            ApplicationUser? registeresUser = await _userInterface.AddUser(user);
            if (registeresUser is null)
            {
                return null;
            }
            return _mapper.Map<AuthenticationResponse>(registeresUser) with { Success = true, Token = "token" }; ;
        }
    }
}
