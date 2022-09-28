using Codebella.Entity;
using Microsoft.AspNetCore.Identity;

namespace Codebella.Extensions
{
    public static class UserManagerExtensions
    {
        public async static Task<Author> GetAuthorByUserEmailAsync(this UserManager<User> userManager, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user.Author;

        }
    }
}