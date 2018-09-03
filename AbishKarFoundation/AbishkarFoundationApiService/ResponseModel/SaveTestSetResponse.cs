using AbishkarFoundation.Web.ViewModel.Module;

namespace AbishkarFoundation.ApiService.ResponseModel
{
    public class SaveTestSetResponse : ResponseBase
    {
        public TestSetCreateViewModel TestSetCreateViewModel { get; set; }
    }
}
