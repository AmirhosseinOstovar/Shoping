using Microsoft.AspNetCore.Mvc;
using Shoping.Domain.Entities.Product;
using Shoping.Persistance.Services.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint_Shoping.Areas.Admin.Controllers

{
    [Area("Admin")]

    public class CategoryContoroller : Controller
    {
        private readonly ICategory _category;
        public CategoryContoroller(ICategory category)
        {
            _category = category;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentid = parentId;
            return View();
        }   
        [HttpPost]
        public IActionResult AddNewCategory(long? parentid, string name)
        {
            Category c = new Category()
            {
                Name = name,
                ParentCategory = _category.Get_Parent(parentid)
            };
            var result = _category.InsertCategory(c);
            _category.Save();
            return Json(c);
        }
    }
}
