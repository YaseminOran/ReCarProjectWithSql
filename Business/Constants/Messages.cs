﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string DescriptionInvalid = "Açıklama geçersiz";
        public static string DailyPriceInvalid = "Günlük kiralama ücreti girmediniz";
        internal static string MaintemanceTime = "Arabalar Listelemeye Kapalı";
        internal static string CarListed = "Arabalar Listelendi";
        public static string CarDelete = "Araba sistemden silindi";
        public static string CarGetById = "Arabalar ID numaralarına göre listelenmistir.";
        public static string CarUpdate = "Seçili araba güncellenmiştir";
        public static string UserAdd = "Kullanıcı eklendi";
        public static string RentalInvalid = "Araç suan başka bir müsterinin kullanımındadır.";
        public static string CarCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string CarNameAlreadyExists="Bu isimde zaten başka bir ürün var";
    }
}
