using AutoRestaurant.Models.BaseModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace AutoRestaurant.Models
{
    public class Autorization : BaseEntity
    {
        [Required, MaxLength(64)]
        public string Login { get; set; }
        [Required, MaxLength(64)]
        public string Password { get; set; }
        public static string GetHash(string input)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}
