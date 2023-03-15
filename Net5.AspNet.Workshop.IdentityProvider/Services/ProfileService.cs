using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Net5.AspNet.Workshop.IdentityProvider.Infrastructure.Data.Security.Entities;
using Net5.AspNet.Workshop.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Services
{
    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;
        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //Processing
            var user = await _userManager.GetUserAsync(context.Subject);
            var claims = new List<Claim>
            {
                new Claim(SecurityClaimType.PersonId, user.PersonId.ToString()),
                new Claim(SecurityClaimType.CategoryId, user.CategoryId.ToString())
            };

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
