using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System.Net;
using System.Net.Mail;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IResetService _resetService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IResetService resetService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _resetService = resetService;
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            SendCode(userForLoginDto);
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
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
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult(Messages.UserNotFound);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> SendCode(UserForLoginDto resetPassword)
        {
            var user = _userService.GetByMail(resetPassword.Email);

            if (user != null)
            {
                var kontrol = _resetService.GetById(user.Id);

                if (kontrol != null)
                {
                    var reset = new ResetPassword
                    {
                        Id = kontrol.Id,
                        Code = getCode(),
                        Status = true,
                        UserId = user.Id
                    };
                    _resetService.Update(reset);
                }

                else
                {
                    var reset = new ResetPassword
                    {
                        Code = getCode(),
                        Status = true,
                        UserId = user.Id
                    };
                    _resetService.Add(reset);
                }
                
                string text = "Sıfırlama için kodunuz : " + getCode();
                string subject = "Parola sıfırlama";
                MailMessage msg = new MailMessage("travelersapp@yandex.com.tr", resetPassword.Email, subject, text);
                msg.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.yandex.com.tr", 587);
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential networkCredential = new NetworkCredential("travelersapp@yandex.com.tr", "kujqcaevthhoeiwj");
                smtpClient.Credentials = networkCredential;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);

                return new SuccessDataResult<User>(user, Messages.NewPasswordCodeSend);
            }

            return new ErrorDataResult<User>(user, Messages.NewPasswordCodeNotSend);
        }

        public string getCode()
        {
            string code = "";
            Random rnd = new Random();

            for (int i = 0; i < 6; i++)
            {
                char tmp = Convert.ToChar(rnd.Next(48, 58));
                code += tmp;
            }
            return code;
        }
    }
}