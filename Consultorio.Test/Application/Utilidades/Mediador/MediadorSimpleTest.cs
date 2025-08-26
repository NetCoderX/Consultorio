using Consultorio.Application.Excepciones;
using Consultorio.Application.Utilidades.Mediador;
using FluentValidation;
using NSubstitute;

namespace Consultorio.Test.Application.Utilidades.Mediador
{
    [TestClass]
    public class MediadorSimpleTest
    {
        public class RequestFalso : IRequest<string> {
            public required string Nombre { get; set; }
        }
        public class HandlerFalso : IRequestHandler<RequestFalso, string>
        {
            public Task<string> Handle(RequestFalso request)
            {
                return Task.FromResult("respuesta correcta");
            }
        }

        public class ValidadorRequestFalso : AbstractValidator<RequestFalso>
        {
            public ValidadorRequestFalso()
            {
                RuleFor(n => n.Nombre).NotEmpty();
            }
        }


        [TestMethod]
        public async Task Send_LLamaMetodoHanlder()
        {
            var request = new RequestFalso(){ Nombre = "Nombre A"};
            var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();
            var servicePorvider = Substitute.For<IServiceProvider>();
            servicePorvider.GetService(typeof(IRequestHandler<RequestFalso, string>))
                .Returns(casoDeUsoMock);

            var mediador = new MediadorSimple(servicePorvider);
            var resultado = await mediador.Send(request);
            await casoDeUsoMock.Received(1).Handle(request);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeMediador))]
        public async Task Send_SinHandlerRegistrado_LanzaExcepcion()
        {
            var request = new RequestFalso() { Nombre = "Nombre A" };
            var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();
            var servicePorvider = Substitute.For<IServiceProvider>();

            var mediador = new MediadorSimple(servicePorvider);
            var resultado = await mediador.Send(request);
        }



        [TestMethod]
        public async Task Send_ComandoNoValido_LanzaExcepcion()
        {
            var request = new RequestFalso { Nombre = "" };
            var serviceProvider = Substitute.For<IServiceProvider>();
            var validator = new ValidadorRequestFalso();

            serviceProvider.GetService(typeof(IValidator<RequestFalso>))
                .Returns(validator);

            var mediador = new MediadorSimple(serviceProvider);
            await Assert.ThrowsExceptionAsync<ExcepcionDeValidacion>(async () =>
            {
                await mediador.Send(request);
            });
        }


    }
}
