using CoreEcommerceUserPanal.Controllers;
using CoreEcommerceUserPanal.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UserPortalTesting.Tests
{
  public  class ProductCategoryTestController
    {
        private ShoppingProjectFinalContext context;
        public static DbContextOptions<ShoppingProjectFinalContext>
            dbContextOptions
        { get; set; }

        public static string connenctionString =
            "Data Source = TRD-520; Initial Catalog=ShoppingProjectFinal; Integrated Security = true;";
        static ProductCategoryTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShoppingProjectFinalContext>()
                .UseSqlServer(connenctionString).Options;
        }
        public ProductCategoryTestController()
        {
            context = new ShoppingProjectFinalContext(dbContextOptions);
        }
        [Fact]
        public async void Task_GetPCById_Return_OkResult()
        {
            var controller = new ProductCategoryController(context);
            var Id = 2;
            var data = await controller.Get(Id);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_GetPCById_Return_FailResult()
        {
            var controller = new ProductCategoryController(context);
            var Id = 25;
            var data = await controller.Get(Id);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_GetPCById_Return_getMatched()
        {
            var controller = new ProductCategoryController(context);
            int id = 1;
            var data = await controller.Get(id);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var pc = okResult.Value.Should().BeAssignableTo<Categories>().Subject;
            Assert.Equal("Summer", pc.CategoryName);
            Assert.Equal("printed", pc.CategoryDescription);

        }
        [Fact]
        public async void Task_GetPCById_Return_getBadRequestResult()
        {
            
            var controller = new ProductCategoryController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);
        }
    }
}
