using AbishkarFoundation.Web.ViewModel.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbishkarFoundation.ApiService.ResponseModel
{
    public class GetTesSetResponse:ResponseBase
    {
        public TestSetCreateViewModel TestSetCreateViewModel { get; set; }
    }
}
