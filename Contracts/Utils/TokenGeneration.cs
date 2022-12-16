using System;

namespace Contracts.Utils
{
    public static class TokenGeneration
    {
        public static string GenerateToken(string username)
        {
            int iat = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var objToken = new
            {
                iat = iat,
                username = username
            };

            string json = json = System.Text.Json.JsonSerializer.Serialize<object>(objToken);
            string token = Cript.EncryptString(json);

            return token;
        }
    }
}
