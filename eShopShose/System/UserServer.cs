using eProjectDemoData.Entity;
using eProjectDemoViewModel.System.Common;
using eProjectDemoViewModel.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eProjectDemoApplication.System
{
    public class UserServer : IUserServer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;

        public UserServer(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            user = new AppUser()
            {
                FullName = request.FullName,
                Dob = request.Dob,
                Email = request.Email,
                UserName = request.UserName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng ký không thành công");
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
                if (!result.Succeeded)
                {
                    return new ApiErrorResult<string>("Đăng nhập không đúng");
                }
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new[]
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.GivenName,user.FullName),
                    new Claim(ClaimTypes.Role, string.Join(";",roles)),
                    new Claim(ClaimTypes.Name, request.UserName)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                    _config["Tokens:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds);
                var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                return new ApiSuccessResult<string>(tokenstring, request.Password, request.UserName);
            }

            return new ApiErrorResult<string>("Tài khoản không tồn tại");
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var user = _userManager.Users;
            var data = await user.Select(m => new UserViewModel()
            {
                Id = m.Id,
                FullName = m.FullName,
                UserName = m.UserName,
                Email = m.Email,
                Dob = m.Dob
            }).ToListAsync();
            return data;
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserViewModel>("User không tồn tại");
            }

            var UserView = new UserViewModel()
            {
                Email = user.Email,
                FullName = user.FullName,
                Dob = user.Dob,
                Id = user.Id,
                UserName = user.UserName,
               
            };
            return new ApiSuccessResult<UserViewModel>(UserView);
        }

        public async Task<ApiResult<bool>> Delete(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());

            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            var reult = await _userManager.DeleteAsync(user);
            if (reult.Succeeded)
                return new ApiSuccessResult<bool>();

            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        public async Task<ApiResult<bool>> Update(Guid Id, UserViewModel request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != Id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            var user = await _userManager.FindByIdAsync(Id.ToString());
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.UserName = request.UserName;
            user.Dob = request.Dob;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");

        }
    }
}
