
using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoViewModel.System.Common
{
    
    public class ApiSuccessResult<T> : ApiResult<T>
    {
       
        public ApiSuccessResult(T resultObj, string password, string userName)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
            Password = password;
            UserName = userName;
       
        }
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;

        }
        public ApiSuccessResult()
        {
            IsSuccessed = true;

        }
        //public ApiSuccessResult(string email, string userName, string fullName)
        //{
        //    IsSuccessed = true;
        //    FullName = fullName;
        //    Email = email;
        //    UserName = userName;

        //}
    }
}
