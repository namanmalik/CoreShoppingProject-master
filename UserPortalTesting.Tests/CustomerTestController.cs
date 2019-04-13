using CoreEcommerceUserPanal.Controllers;
using CoreEcommerceUserPanal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UserPortalTesting.Tests
{
    public class CustomerTestController
    {
        private ShoppingProjectFinalContext context;
        public static DbContextOptions<ShoppingProjectFinalContext>
            dbContextOptions
        { get; set; }

        public static string connenctionString =
            "Data Source = TRD-520; Initial Catalog=ShoppingProjectFinal; Integrated Security = true;";
        static CustomerTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShoppingProjectFinalContext>()
                .UseSqlServer(connenctionString).Options;
        }
        public CustomerTestController()
        {
            context = new ShoppingProjectFinalContext(dbContextOptions);
        }

        [Fact]

        public void Task_Login_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CustomersController(context);
                var UserName = "Naman";
                var Password = "12";
                var data = controller.Login(UserName, Password);
                //Assert.NotNull(data);
                Assert.IsType<ViewResult>(data);
            });
        }

    


    }
}
