﻿using System.Web;
using System.Web.Mvc;

namespace MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {            
            filters.Add(new HandleErrorAttribute());//Old line
            filters.Add(new AuthorizeAttribute());//New Line
        }
    }
}
