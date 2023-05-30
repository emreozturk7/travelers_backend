﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi.";
        public static string ProductDeleted = "Ürün başarıyla silindi.";
        public static string ProductUpdated = "Ürün başarıyla güncellendi.";
        public static string CategoryAdded = "Kategori başarıyla eklendi.";
        public static string CategoryDeleted = "Kategori başarıyla silindi.";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı!";

        public static string PasswordError = "Şifre hatalı!";

        public static string SuccessfulLogin = "Sisteme giriş başarılı.";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu.";

        public static string NewPasswordCodeSend = "Kod başarıyla gönderildi.";
        public static string NewPasswordCodeNotSend = "Kod gönderimi başarısız!";

        public static string NewStatus = "Durum başarılı bir şekilde güncellendi.";
        public static string StatusNotUpdate = "Kod başarıyla gönderildi.";

        public static string CodeNotSend = "Kod gönderilemiyor. Zaman aşımına uğradı!";

        public static string AreasAdded = "Alana başarıyla eklendi.";
        public static string AreasDeleted = "Alan başarıyla silindi.";
        public static string AreasUpdate = "Alan başarıyla güncellendi.";

        public static string FavoriteAdded = "Favorilere eklendi.";
        public static string FavoriteUpdate = "Favoriler güncellendi.";
    }
}
