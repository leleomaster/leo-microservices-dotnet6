using GeekShooping.New.Web.Models;
using GeekShooping.New.Web.Services.IServices;
using GeekShooping.New.Web.Services.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.New.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var acessToken = await HttpContext.GetTokenAsync("access_token");
            var products = await _productService.FindAll(acessToken);

            return View(products);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            var acessToken = await HttpContext.GetTokenAsync("access_token");
            var products = await _productService.FindAll(acessToken);

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var acessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.Create(model, acessToken);

                if (response != null)
                    return RedirectToAction("ProductIndex");

                return View(response);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductEdit(long id)
        {
            var acessToken = await HttpContext.GetTokenAsync("access_token");
            var product = await _productService.FindById(id, acessToken);

            if (product != null)
                return View(product);

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var acessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.Update(model, acessToken);

                if (response != null)
                    return RedirectToAction("ProductIndex");

                return View(response);
            }

            return View(model);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ProductDelete(long id)
        {
            var acessToken = await HttpContext.GetTokenAsync("access_token");
            var product = await _productService.FindById(id, acessToken);

            if (product != null)
                return View(product);

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var acessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.Delete(model.Id, acessToken);

            if (response)
                return RedirectToAction(nameof(ProductIndex));

            return View(model);
        }
    }
}
