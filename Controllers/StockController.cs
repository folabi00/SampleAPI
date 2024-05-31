using Microsoft.AspNetCore.Mvc;
using SampleAPI.Data;
using SampleAPI.DTOs;
using SampleAPI.Exceptions;
using SampleAPI.Models;
using SampleAPI.Models.Repository;
using SampleAPI.Models.Validations;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAPI.Controllers
{
    /*[Route("api/[controller]")]*/
    [ApiController]
    [Route ("/api/[Controller]")]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public StockController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        
        [HttpGet]
        public IActionResult GetStock()
        {
            var allStocks = _appDbContext.Stocks.ToList();
            return Ok(allStocks);
          
        }

        
        [HttpGet("{id}")]
        public IActionResult GetStockById(int id)
        {
            if (id <= 0 ) return BadRequest();
                else if(!_appDbContext.StockExists(id)) return NotFound();
            var stocked = _appDbContext.IsValid(id);
           return Ok(stocked);
          
        }

        [HttpPost]
        
        public IActionResult CreateStock([FromBody] StockDTO newStockdto)
        {
            var newStock = new Stock() { Name = newStockdto.Name , Description = newStockdto.Description, Stocksize = newStockdto.Stocksize};

            if (_appDbContext.StockNameExists(newStock.Name))
            {
                throw new DuplicateStockException();
            }

            newStock.LastModified = DateTime.Now;
            var addedStock = _appDbContext.Add(newStock);
            _appDbContext.SaveChanges();
            return Ok(newStock);
        }
        


        
        [HttpPut("{id}")]
        public IActionResult UpdateStock(int id, [FromBody] StockDTO updatedstockdto)
        {
           
            if (updatedstockdto == null)
            {
                return BadRequest();
            }

            var existingStock = _appDbContext.IsValid(id);
            
            if(existingStock == null)
            {
                return NotFound();
            }

            existingStock.Name = updatedstockdto.Name;
            existingStock.Description = updatedstockdto.Description;
            existingStock.Stocksize = updatedstockdto.Stocksize;
            existingStock.LastModified = DateTime.Now;
           
            _appDbContext.Update(existingStock);
            _appDbContext.SaveChanges();
            return Ok(existingStock);
        }

     
        
        [HttpDelete("{id}")]
        public IActionResult DeleteStock(int id)
        {
            if(id <= 0 )
            {
                return BadRequest();
            }

            if (!_appDbContext.StockExists(id))
            {
                return NotFound();
            }
            var existingStock = _appDbContext.IsValid(id);

            _appDbContext.Stocks.Remove(existingStock);
            _appDbContext.SaveChanges();

            return Ok();
        }
    }
}
