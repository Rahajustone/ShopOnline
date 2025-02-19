﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Extensions;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItems();
                var productCategories = await _productRepository.GetCategories();

                if(products == null || productCategories == null)
                    return NotFound();

                var productDtos = products.ConvertToDto(productCategories);

                return Ok(productDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
           }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await _productRepository.GetItem(id);

                if (product == null)
                    return NotFound();

                var productCategory = await this._productRepository.GetCategory(product.CategoryId);
                var productDto = product.ConvertToDto(productCategory);

                return Ok(productDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}

