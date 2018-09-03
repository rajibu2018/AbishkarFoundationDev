using AbishkarFoundation.Web.ViewModel.Module;
using System.Collections.Generic;

namespace AbishkarFoundation.ApiService.ResponseModel
{
    public class UsersModuleRespons: ResponseBase
    {
        public TestSetViewModel TesSetViewModel { get; set; }
        public UsersModuleRespons()
        {
            TesSetViewModel = new TestSetViewModel();
        }
    }
}
