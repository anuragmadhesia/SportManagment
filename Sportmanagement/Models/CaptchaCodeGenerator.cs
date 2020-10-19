using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sportmanagement.Models
{
    public class CaptchaCodeGenerator
    {
        public string GetCaptch()
        {
            char ch1,ch2,ch3,ch4,ch5;
            Random rm = new Random();
           ch1= (char)(rm.Next(65, 90));
           ch2 = (char)(rm.Next(50, 55));
           ch3 = (char)(rm.Next(100, 122));
           ch4 = (char)(rm.Next(50, 55));
           ch5 = (char)(rm.Next(50,54));
           string cph = ch1 +""+ ch2 +""+ ch3 +""+ ch4 +""+ ch5+"";
           return cph;
        }
    }
}