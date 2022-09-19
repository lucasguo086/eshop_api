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

    [Route("api")]
    [ApiController]
    public class EshopController : Controller
    {
        private readonly IEshopRepo _repository;

        public EshopController(IEshopRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet("ViewProducts")]
        public ActionResult ViewProducts()
        {
            IEnumerable<Product> products = _repository.GetAllProducts();
            return Ok(products);
        }

    }

