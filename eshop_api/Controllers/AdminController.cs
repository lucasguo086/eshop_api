namespace eshop_api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eshop_api.Data;
using eshop_api.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

[Route("admin")]
[ApiController]
public class AdminController : Controller
{
    private readonly IEshopRepo _repository;

    public AdminController(IEshopRepo repository)
    {
        _repository = repository;
    }
    
        
    [Authorize(AuthenticationSchemes = "EshopAuthentication")]
    [Authorize(Policy = "AdminOnly")]
    [HttpGet("ListAllProductsAdmin")]
    public ActionResult ListAllAdmin()
    {
        IEnumerable<Product> products = _repository.GetAllProducts();
        return Ok(products);
    }
}