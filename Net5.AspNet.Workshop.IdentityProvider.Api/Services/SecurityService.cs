using AutoMapper;
using Microsoft.AspNetCore.Http;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Repositories;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Helper;
using Net5.AspNet.Workshop.Infrastructure.Constants;
using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly SecurityUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecurityService(
            SecurityUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IEmailSender emailSender
        )
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public UserDto GetUserByUserName(string userName)
        {
            return _mapper.Map<UserDto>(_unitOfWork.Users.GetUserByUserName(userName));
        }
        public async Task<bool> ForgotPasswordAsync(string userName, string email)
        {
            bool isOk = false;
            User user = _unitOfWork.Users.GetUserByUserName(userName);

            if (user.Email == email)
            {
                _unitOfWork.Users.UpdatePassword(userName, "P@ssword1234");
                _unitOfWork.Save();
                await _emailSender.SendEmailAsync(email, "New Password", "Your new password in P@ssword1234");
                isOk = true;
            }

            return isOk;
        }

        public async Task<UserDto> InsertUserAsync(UserDto userDto)
        {
            Role role = _unitOfWork.Roles.GetAll(r => r.NormalizedName == Roles.Enrolled.ToUpper()).FirstOrDefault();
            User user = _mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid().ToString();
            user.EmailConfirmed = true;
            user.NormalizedUserName = user.UserName.ToUpper();
            user.NormalizedEmail = user.Email.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.ConcurrencyStamp = Guid.NewGuid().ToString();
            user.LockoutEnabled = true;
            user.Person.Address.Department = null;
            user.Person.Address.Province = null;
            user.Person.Address.District = null;
            user.UserRoles.Add(new UserRole { Role = role });

            _unitOfWork.Users.Insert(user);
            _unitOfWork.Save();

            _unitOfWork.Users.UpdatePassword(user.UserName, "P@ssword1234");
            _unitOfWork.Save();

            await _emailSender.SendEmailAsync(user.Email, "Register user", "Your new password in P@ssword1234");

            userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
