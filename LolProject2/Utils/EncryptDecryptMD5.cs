using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LolProject2
{
    public  class EncryptDecryptMD5
    {
        public static string Encrypt(string encryptString)
        {
            /*  using(MD5 md5 = MD5.Create())
              {
                  byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(encryptString);
                  byte[] hashBytes = md5.ComputeHash(inputBytes);

                  return Convert.ToBase64String(hashBytes);
              } */
            /* MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
             byte[] encrypt;
             UTF8Encoding encode = new UTF8Encoding();
             //encrypt the given password string into Encrypted data  
             encrypt = md5.ComputeHash(encode.GetBytes(encryptString));
             StringBuilder encryptdata = new StringBuilder();
             //Create a new string by using the encrypted data  
             for (int i = 0; i < encrypt.Length; i++)
             {
                 encryptdata.Append(encrypt[i].ToString());
             }
             return encryptdata.ToString(); */
            //Лучше не использовать сейчас
            string EncryptionKey = "3a4V7JCxW1RdDMj2";    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        public static string Decrypt(string decryptString)
        {
            string EncryptionKey = "3a4V7JCxW1RdDMj2";  
            decryptString = decryptString.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(decryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    decryptString = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
           
            return decryptString;
        }
    }
}
