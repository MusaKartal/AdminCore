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
       
       private readonly IProduct _productServices;
       
       public AdminController(IProduct services)
        {
            _productServices = services;
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
        public async Task<IActionResult> Create(IFormFile file,Product model)
        {
            
            
            await _productServices.ImageUploadItem(file, model);
                
            
            return RedirectToAction("List");
        }

       

        [HttpGet]
        public async Task <IActionResult> Details(int id )
        {
            var result = await _productServices.GetProductById(id);
            return View(result); 
        }

      

        [HttpGet]
        public async  Task <IActionResult> List()
        {
            var result = await _productServices.GetItemAll(); 

            return View(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productServices.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public  async Task<IActionResult> Edit(IFormFile file,int id,Product model)
        {
           
           await _productServices.ImageUpdateItem(file, id, model);
           return  RedirectToAction("List");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productServices.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id ,Product model)
        {

            await _productServices.DeleteItem(id ,model); 
                
            return RedirectToAction("List");
        }

     
    }
}
