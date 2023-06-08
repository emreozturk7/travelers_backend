using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class ErrorMessages
    {
        public static string UserNotFoundError = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Şifre hatalı!";
        public static string UserAlreadyExistsError = "Bu kullanıcı zaten mevcut.";
        public static string UserNotRegisteredError = "Kullanıcı başarıyla kaydedilemedi.";
        public static string NewPasswordCodeNotSendError = "Kod gönderimi başarısız!";
        public static string StatusNotUpdateError = "Kod başarıyla gönderildi.";
        public static string CodeNotSendError = "Kod gönderilemiyor. Zaman aşımına uğradı!";
        public static string PasswordINvalidError = "Parola veya E-mail uygun değil.";
    }
}
