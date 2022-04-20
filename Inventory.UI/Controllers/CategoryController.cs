using Inventory.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Core.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ICategoryService _categoryService;
        public CategoryController(IConfiguration Config, ICategoryService categoryService)
        {
            _config = Config;
            _categoryService = categoryService;
        }
        public ViewResult Index()
        {
            var data = _categoryService.GetCategoryList();
            return View();
        }
    }
}
