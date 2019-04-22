using CoreEcommerceUserPanal.Controllers;
using CoreEcommerceUserPanal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace UserPortalTesting.Tests
{
    public class CartTestController
    {
        private ShoppingProjectFinalContext context;
        public static DbContextOptions<ShoppingProjectFinalContext>
            dbContextOptions
        { get; set; }

        public static string connenctionString =
            "Data Source = TRD-520; Initial Catalog=ShoppingProjectFinal; Integrated Security = true;";
        static CartTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShoppingProjectFinalContext>()
                .UseSqlServer(connenctionString).Options;
        }
        public CartTestController()
        {
            context = new ShoppingProjectFinalContext(dbContextOptions);
        }

        [Fact]
        public void Task_Index_Return_ViewResult()
        {

            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);

                var data = controller.Index();

                Assert.Null(data);

                var viewResult = Assert.IsType<ViewResult>(data);
            });

        }
        [Fact]
        public void Task_remove_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var Id = 1;
                var data = controller.Remove(Id);
                Assert.IsType<ViewResult>(data);
            });
        }
        [Fact]
        public void Task_Plus_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var Id = 1;
                var data = controller.Plus(Id);
                Assert.IsType<ViewResult>(data);
            });
        }
        [Fact]
        public void Task_Minus_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var Id = 1;
                var data = controller.Minus(Id);
                Assert.IsType<ViewResult>(data);
            });
        }
        [Fact]
        public void Task_Buy_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var Id = 1;
                var data = controller.Buy(Id);
                Assert.IsType<ViewResult>(data);
            });
        }
        [Fact]
        public void Task_Invoice_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);

                var data = controller.Invoice();
                Assert.IsType<ViewResult>(data);
            });
        }


    }
}

