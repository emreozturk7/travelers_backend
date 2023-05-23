using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ResetManager : IResetService
    {
        private IResetDal _resetDal;
        private IUserService _userService;

        public ResetManager(IResetDal resetDal, IUserService userService)
        {
            _resetDal = resetDal;
            _userService = userService;
        }

        public void Add(ResetPassword reset)
        {
            _resetDal.Add(reset);
        }
        public void Update(ResetPassword reset)
        {
            _resetDal.Update(reset);
        }
        public ResetPassword GetById(int userId)
        {
            return _resetDal.Get(filter: u => u.UserId == userId);
        }

        public IDataResult<User> SendCode(string email)
        {
            var user = _userService.GetByMail(email);

            if (user != null)
            {
                var kontrol = GetById(user.Id);

                string code = getCode();

                if (kontrol != null)
                {
                    var reset = new ResetPassword
                    {
                        Id = kontrol.Id,
                        Code = code,
                        Status = true,
                        UserId = user.Id
                    };
                   Update(reset);
                }

                else
                {
                    var reset = new ResetPassword
                    {
                        Code = code,
                        Status = true,
                        UserId = user.Id
                    };
                    Add(reset);
                }

                string text = "Sıfırlama için kodunuz : " + code;
                string subject = "Parola sıfırlama";
                MailMessage msg = new MailMessage("travelersapp@yandex.com.tr", email, subject, text);
                msg.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.yandex.com.tr", 587);
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential networkCredential = new NetworkCredential("travelersapp@yandex.com.tr", "kujqcaevthhoeiwj");
                smtpClient.Credentials = networkCredential;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);

                // Timer ekle

                return new SuccessDataResult<User>(user, Messages.NewPasswordCodeSend);
            }

            return new ErrorDataResult<User>(user, Messages.NewPasswordCodeNotSend);
        }

        public IDataResult<User> CheckCode(string email, string code) {
            var user = _userService.GetByMail(email);

            // Check et

            
            return new SuccessDataResult<User>(user, Messages.NewPasswordCodeSend);
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
