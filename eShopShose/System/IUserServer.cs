using eProjectDemoViewModel.System.Common;
using eProjectDemoViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eProjectDemoApplication.System
{
    public interface IUserServer
    {
        Task<List<UserViewModel>> GetAll();
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<UserViewModel>> GetById(Guid Id);
        Task<ApiResult<bool>> Delete(Guid Id);
        Task<ApiResult<bool>> Update(Guid Id, UserViewModel request);
    }
}
