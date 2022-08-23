using AdminCore.Business.Abstract;
using AdminCore.Business.Concrete;
using AdminCore.Business.Filters;
using AdminCore.Data;
using AdminCore.Models;
using AdminCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AdminCore.Controllers
{
    [AdminFilter]
    public class AdminController : Controller
    {
        
      
        private readonly IProduct _services;

       public AdminController(IProduct services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            await  _services.CreateItem(model);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task <IActionResult> Details(int id )
        {
            var result = await _services.GetProductById(id);
            return View(result); 
        }

      

        [HttpGet]
        public async  Task <IActionResult> List()
        {
            var result = await _services.GetItemAll(); 

            return View(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _services.GetProductById(id);

            return View(product);
        }

        [HttpPost]
        public  async Task<IActionResult> Edit(int id,Product model)
        {
           
            await _services.UpdateItem(id,model);
           return  RedirectToAction("List");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _services.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product model)
        {
            await _services.DeleteItem(model.Id);
            return RedirectToAction("List");
        }

     
    }
}
