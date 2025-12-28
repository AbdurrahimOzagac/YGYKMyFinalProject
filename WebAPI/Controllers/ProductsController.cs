using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{   
    IProductService _productservice;

    public ProductsController(IProductService productService)
    {
        _productservice = productService;
    }
    [HttpGet]
    public List<Product> Get()
    {
        IProductService productService = new ProductManager(new EFProductDal());
        var result = productService.GetAll();
        return result.Data;
    }
}
