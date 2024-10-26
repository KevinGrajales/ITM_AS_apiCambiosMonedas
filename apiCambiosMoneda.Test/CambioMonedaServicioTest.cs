
using apiCambiosMoneda.Aplicacion.Servicios;
using apiCambiosMoneda.Core.Interfaces.Repositorios;
using apiCambiosMoneda.Core.Interfaces.Servicios;
using apiCambiosMoneda.Dominio.Entidades;
using Moq;

namespace apiCambiosMoneda.Test
{
    public class CambioMonedaServicioTest
    {

        private readonly Mock<IMonedaRepositorio> monedaRepositorioMock;
        private readonly IMonedaServicio monedaServicio;

        public CambioMonedaServicioTest()
        {
            monedaRepositorioMock = new Mock<IMonedaRepositorio>();
            monedaServicio = new MonedaServicio(monedaRepositorioMock.Object);
        }

        [Fact]
        public async void ObtenerHistorialCambios_RetornandoListaDeCambios()
        {
            //Arrange
            var idMoneda = 35;
            var desde = new DateTime(2024, 5, 15);
            var hasta = new DateTime(2024, 5, 31);

            var listaCambios = new List<CambioMoneda>
            {
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 15), Cambio=4050 },
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 16), Cambio=4060 },
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 17), Cambio=4100 },
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 18), Cambio=4050 },
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 19), Cambio=4052 }
            }.AsEnumerable();

            monedaRepositorioMock.Setup(repositorio => repositorio.ObtenerHistorialCambios(idMoneda, desde, hasta))
                .ReturnsAsync(listaCambios);

            //Act
            var resultado = await monedaServicio.ObtenerHistorialCambios(idMoneda, desde, hasta);

            //Assert
            Assert.Equal(5, resultado.ToList().Count);
            Assert.Equal(4060, resultado.ToList()[1].Cambio);
            Assert.Equal(4052, resultado.Last().Cambio);
        }

        [Fact]
        public async void ObtenerCambioActual_RetornandoUltimoCambio()
        {
            //Arrange
            var idMoneda = 35;
            var cambioMonedaActual = new CambioMoneda { IdMoneda = idMoneda, Fecha = new DateTime(2024, 5, 15), Cambio = 4050 };

            monedaRepositorioMock.Setup(repositorio => repositorio.ObtenerCambioActual(idMoneda))
                .ReturnsAsync(cambioMonedaActual);

            //Act
            var resultado = await monedaServicio.ObtenerCambioActual(idMoneda);

            //Assert
            Assert.NotNull(resultado);
            Assert.Equal(4050, resultado.Cambio);
        }


    }
}
