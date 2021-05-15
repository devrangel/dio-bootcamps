using Domain.Commands;
using Domain.Handlers;
using Domain.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Repositories;

namespace Tests.Handlers
{
    [TestClass]
    public class OrderHandlerTests
    {
        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "12684257";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }
    }
}
