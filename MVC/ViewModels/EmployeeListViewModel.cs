using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> EmployeeViewModels { get; set; }
        public string UserName { get; set; }
        public FooterViewModel FooterData { get; set; }
    }
}