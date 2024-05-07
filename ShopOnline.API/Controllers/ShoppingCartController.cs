using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Entities;
using ShopOnline.API.Extensions;
using ShopOnline.API.Repositories;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public readonly IProductRepository _productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        // GET: api/values
        [HttpGet]
        [Route("{userId}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await this._shoppingCartRepository.GetItems(userId);
                if (cartItems == null) return NoContent();

                var products = await this._productRepository.GetItems();
                if (products == null) throw new Exception("No Product exist in the system");

                var cartItemsDto = cartItems.ConvertToDto(products);

                return Ok(cartItemsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await this._shoppingCartRepository.GetItem(id);
                if (cartItem == null) return NoContent();

                var product = await _productRepository.GetItem(cartItem.ProductId);
                if (product == null) return NoContent();

                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var newCartItem = await this._shoppingCartRepository.AddItem(cartItemToAddDto);
                if (newCartItem == null) return NoContent();

                var product = await _productRepository.GetItem(newCartItem.ProductId);
                if (product == null) throw new Exception($"Something went wront when attemping to retrieve product(productid:({product.Id})");

                var newCartItemDto = newCartItem.ConvertToDto(product);

                return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

