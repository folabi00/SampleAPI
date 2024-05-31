using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Data;
using SampleAPI.DTOs;
using System;

namespace SampleAPI.Models.Validations
{
    public class Stock_CreateFIlter_Validate : ActionFilterAttribute
    {
        private readonly AppDbContext _dbContext;

        public Stock_CreateFIlter_Validate(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            

            base.OnActionExecuting(context);

            AppDbContext dbContext = _dbContext;
            var stocks = context.ActionArguments["newStockdto"] as StockDTO;    
            if(stocks != null)
            {
                context.ModelState.AddModelError("StockDTO","Stock is null");
                var problemdetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest

                };
                context.Result = new BadRequestObjectResult(problemdetails);
            } 
            else
            {
                var existingStock = dbContext.StockNameExists(stocks.Name);
                if(existingStock == null)
                {
                    context.ModelState.AddModelError("StockDTO", "Stock already exists");
                    var problemdetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest

                    };
                    context.Result = new BadRequestObjectResult(problemdetails);
                }
            }

        }

        
    }
}
