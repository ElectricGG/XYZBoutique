using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XYZBoutique.Application.Interface;
using XYZBoutique.Application.UseCase.UseCases.Pedido.Commands.CreateCommand;
using XYZBoutique.Application.UseCase.UseCases.Pedidos.Commands.CreateCommand;
using XYZBoutique.Utilities;

namespace XYZBoutique.Test.Pedido
{
    [TestClass]
    public class PedidoApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task RegisterPedido_WhenSendingNullValuesOrEmpty()
        {
            using var scope = _scopeFactory?.CreateScope();
            var pedidoRepository = scope?.ServiceProvider.GetService<IPedidoRepository>();
            var mapper = scope?.ServiceProvider.GetService<IMapper>(); // Obtén el IMapper del proveedor de servicios
            var validator = scope?.ServiceProvider.GetService<PedidoValidator>(); 

            var handler = new CreatePedidoHandler(pedidoRepository, mapper, validator);

            // Arrange
            var IdUsuarioSolicitante = 1;
            var Repartidor = "Jesus Anderso";

            var expected = ReplyMessage.MESSAGE_SAVE;

            // Act
            var result = await handler.Handle(new CreatePedidoCommand
            {
                IdUsuarioSolicitante = IdUsuarioSolicitante,
                Repartidor = Repartidor,
                DetallePedido = new List<DetallePedidoCommand>
                {
                    new DetallePedidoCommand
                    {
                        IdProducto = 1,
                        Cantidad = 1,
                        Precio = (decimal?)99.9,
                        Total = 1
                    }
                }
            }, default);

            // Assert 
            Assert.AreEqual(expected, result.Message);
        }
    }
}
