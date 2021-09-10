using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoViewModel.System.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }

        public T ResultObj { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
