using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AbishkarFoundation.Model;

namespace AbishkarFoundation.Web.ViewModel.Module
{
   public class TestSetCreateViewModel : TestSetBase
    {
        public int TestSetId { get ; set ; }
        [Required(ErrorMessage ="Please enter Test Name")]
        public bool TestName { get ; set ; }
        public DateTime CreateDate { get ; set ; }
        public TestSetAccessType AccessType { get ; set ; }
        public bool RepeatedAccess { get ; set ; }
        public int? Duration { get ; set ; }
        public DateTime? ActiveUpto { get ; set ; }
        public bool Active { get ; set ; }    
        public string ViewName { get; set; }
        public TestSetCreateViewModel()
        {
            ViewName = "Add Module";
        }
    }
}
