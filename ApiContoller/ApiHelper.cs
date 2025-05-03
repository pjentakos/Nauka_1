using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SqlLite_TEST.ApplicationController;
using SqlLite_TEST.ApplicationController.Models;

namespace SqlLite_TEST.ApiContoller
{
    internal static class ApiHelper
    {
        public static bool IsAuthorized (HttpRequest r)
        {
            if (r.Headers.TryGetValue("Authorization", out var h))
            {
                if (h.ToString().StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                {
                    // Wyciągamy zakodowaną część
                    var encodedCredentials = h.ToString().Substring("Basic ".Length).Trim();
                    var decodedBytes = Convert.FromBase64String(encodedCredentials);
                    var decodedCredentials = System.Text.Encoding.UTF8.GetString(decodedBytes);

                    // Rozdzielamy na login i hasło
                    var parts = decodedCredentials.Split(':', 2);
                    if (parts.Length == 2)
                    {
                        string login = parts[0];
                        string pass = parts[1];

                        User u = new($"login = '{login}'");

                        if (u.Id != 0)
                        {
                            return Password.VerifyPassword(pass, u.PasswordHash, u.PasswordSalt);
                        }
                    }
                }
            }

            return false;

        }
    }
}
