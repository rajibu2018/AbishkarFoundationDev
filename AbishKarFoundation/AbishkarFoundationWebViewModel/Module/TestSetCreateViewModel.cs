using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AbishkarFoundation.Model;

namespace AbishkarFoundation.Web.ViewModel.Module
{
    public class TestSetCreateViewModel : ITestSetBase
    {
        public int TestSetId { get; set; }
        [Required(ErrorMessage = "Please enter Test Name")]
        [Display(Name = "Test Name")]
        public string TestName { get; set; }
        public DateTime CreateDate { get; set; }
        [Display(Name = "Access Type")]
        public TestSetAccessType AccessType { get; set; }
        [Display(Name = "Repeate Test")]
        public bool RepeatedAccess { get; set; }
        public int? Duration { get; set; }
        [Display(Name = "Active Upto")]
        public DateTime? ActiveUpto { get; set; }
        [Display(Name = "Status")]
        public bool Active { get; set; }
        public string ViewName { get; set; }
        public int CreatorId { get; set; }

        public TestSetCreateViewModel()
        {
            ViewName = "Add Module";
        }
    }
}
