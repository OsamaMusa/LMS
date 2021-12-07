using System;
using System.Collections.Generic;
using System.Text;

 namespace Data
{
    public  static class EncreptPassword
    {
        public static string EncodePass(string pass)
        {
            if (String.IsNullOrEmpty(pass)) return "";
            pass += "this is my custom Secret key for authnetication";
            var result = Encoding.UTF8.GetBytes(pass);
            return Convert.ToBase64String(result);

        }
    }
}
