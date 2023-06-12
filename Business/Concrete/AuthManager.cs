using Business.Abstract;
using Business.Constants;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(ErrorMessages.UserNotFoundError);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(ErrorMessages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, SuccessMessages.SuccessfulLoginSuccess);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };

            var controlPassword = PasswordControl(password);
            var controlEmail = EmailControl(user.Email);

            if (controlPassword && controlEmail)
            {
                _userService.Add(user);
                return new SuccessDataResult<User>(user, SuccessMessages.UserRegisteredSuccess);
            }

            return new ErrorDataResult<User>(user, ErrorMessages.UserNotRegisteredError);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(ErrorMessages.UserAlreadyExistsError);
            }
            return new SuccessResult(ErrorMessages.UserNotFoundError);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, SuccessMessages.AccessTokenCreatedSuccess);
        }

        public static bool PasswordControl(string password)
        {
            int counter = 0;

            if (password.Contains(" "))
                return false;

            if (password.Length < 8)
                return false;

            foreach (char c in password)
            {
                if (Char.IsDigit(c)) { counter++; }
            }

            if (counter == 0)
                return false;

            return true;
        }

        public static bool EmailControl(string email)
        {
            int counter = 0;

            for (int i = 0; i < email.Length; i++)
            {
                string convert = email[i].ToString();

                if (email.Length - 2 == i || email.Length - 3 == i || email.Length - 4 == i)
                {
                    if (convert == ".")
                        counter++;
                }

                if (email.Length - 7 == i || email.Length - 8 == i || email.Length - 9 == i ||
                    email.Length - 10 == i || email.Length - 11 == i || email.Length - 12 == i)
                {
                    if (convert == "@")
                        counter++;
                }
            }

            if (counter == 2)
                return true;

            return false;
        }
    }
}