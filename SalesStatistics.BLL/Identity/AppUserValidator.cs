using Microsoft.AspNet.Identity;
using SalesStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesStatistics.BLL.Identity
{
    public class AppUserValidator : IIdentityValidator<User>
    {
        public async Task<IdentityResult> ValidateAsync(User user)
        {
            List<string> errors = new List<string>();
            if (String.IsNullOrEmpty(user.UserName.Trim()))
            {
                errors.Add("Вы указали пустое имя.");
            }
            string userNamePattern = @"^[a-zA-Z0-9а-яА-Я]+$";
            if (!Regex.IsMatch(user.UserName,userNamePattern))
            {               
                    errors.Add("В имени разрешается указывать буквы английского или русского языков, и цифры");                                
            }
            if (errors.Count > 0)
                return IdentityResult.Failed(errors.ToArray());
            return IdentityResult.Success;
        }
    }
}
