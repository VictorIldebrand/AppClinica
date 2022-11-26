using System;
using System.Security.Cryptography;

namespace Contracts.Utils
{
    public class Rules{
        public static bool Check48HoursBefore(DateTime value, DateTime timeNow)
        {
            var weekDay = (int)value.DayOfWeek; //1->segunda 2->terça
            if (weekDay == 1){
                timeNow.AddHours(96);
            }else if (weekDay == 2){
                timeNow.AddHours(72);
            }else{
                timeNow.AddHours(48);
            }
            if(timeNow <= value)
                return true;
            return false;
        }
    }

    public class Cript
    {
        private static string key = EnviromentVariables.GetEncryptKey().Result;



        public static string EncryptString(string Message)
        {
            string Passphrase = key;
            byte[] Results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return Convert.ToBase64String(Results);
        }
        public static string DecryptString(string Message)
        {
            try
            {
                string Passphrase = key;
                byte[] Results;

                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                byte[] DataToDecrypt = Convert.FromBase64String(Message);

                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                finally
                {
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                return UTF8.GetString(Results);
            }
            catch
            {
                return "";
            }
        }
    }
}
