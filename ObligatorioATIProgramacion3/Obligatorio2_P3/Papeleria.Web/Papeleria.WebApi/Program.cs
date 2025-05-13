using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Papeleria.AccesoDatos.EntityFramework.Repositorios;
using Papeleria.LogicaAplicacion.CasosDeUso.Administradores;
using Papeleria.LogicaAplicacion.CasosDeUso.Articulos;
using Papeleria.LogicaAplicacion.CasosDeUso.Configuraciones;
using Papeleria.LogicaAplicacion.CasosDeUso.Encriptacion;
using Papeleria.LogicaAplicacion.CasosDeUso.Movimientos;
using Papeleria.LogicaAplicacion.CasosDeUso.Pedidos;
using Papeleria.LogicaAplicacion.CasosDeUso.TiposMovimientos;
using Papeleria.LogicaAplicacion.InterfacesCU.Administradores;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Configuraciones;
using Papeleria.LogicaAplicacion.InterfacesCU.Encriptacion;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.InterfacesCU.TiposMovimientos;

using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Swashbuckle.AspNetCore.Filters;

namespace Papeleria.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Inicializamos Repositorios
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimientoEF>();
            builder.Services.AddScoped<IRepositorioMovimiento, RepositorioMovimientoEF>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioConfiguracion, RepositorioConfiguracionEF>();


            //Inicializamos Casos de Uso
            //CU Articulo
            builder.Services.AddScoped<IObtenerArticulos, ObtenerArticulosCU>();
            builder.Services.AddScoped<IObtenerArticulosConMovimientosEntreFechas, ObtenerArticulosConMovimientosEntreFechasCU>();
            //CU Pedido
            builder.Services.AddScoped<IObtenerPedidos, ObtenerPedidosCU>();
            //CU TipoMovimiento
            builder.Services.AddScoped<IObtenerTiposMovimientos, ObtenerTiposMovimientosCU>();
            builder.Services.AddScoped<IObtenerTipoMovimientoPorId, ObtenerTipoMovimientoPorIdCU>();
            builder.Services.AddScoped<IAgregarTipoMovimiento, AgregarTipoMovimientoCU>();
            builder.Services.AddScoped<IModificarTipoMovimiento, ModificarTipoMovimientoCU>();
            builder.Services.AddScoped<IEliminarTipoMovimiento, EliminarTipoMovimientoCU>();

            //CU Movimiento
            builder.Services.AddScoped<IObtenerMovimientos, ObtenerMovimientosCU>();
            builder.Services.AddScoped<IObtenerMovimientoPorId, ObtenerMovimientosPorIdCU>();
            builder.Services.AddScoped<IAgregarMovimiento, AgregarMovimientoCU>();
            builder.Services.AddScoped<IObtenerMovimientosArticuloPorTipo, ObtenerMovimientosArticuloPorTipoCU>();
            builder.Services.AddScoped<IObtenerResumen, ObtenerResumenCU>();
            builder.Services.AddScoped<IExisteMovimientoDeTipo, ExisteMovimientoDeTipoCU>();

            //CU Usuario
            builder.Services.AddScoped<IObtenerUsuarioPorCorreo, ObtenerUsuarioPorCorreoCU>();
            builder.Services.AddScoped<IEncriptarPassword, EncriptarPasswordCU>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuarioCU>();

            //CU Configuracion
            builder.Services.AddScoped<IObtenerValorConfigPorNombre, ObtenerValorConfigPorNombreCU>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var clave = "UruguayCAmpeondeAM3ricaDOSMILVEInti4!,ComoENel2milOncE";
            builder.Services.AddAuthentication(
                aut =>
                {
                    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(opciones =>
                {
                    opciones.RequireHttpsMetadata = false;
                    opciones.SaveToken = true;
                    opciones.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(clave)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                }
            );


            var rutaArchivoXML = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Papeleria.WebApi.xml");
            builder.Services.AddSwaggerGen(
                opciones =>
                {
                    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                    {
                        Description = "Autorización estándar mediante esquema Bearer",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    opciones.OperationFilter<SecurityRequirementsOperationFilter>();
                    opciones.IncludeXmlComments(rutaArchivoXML);
                    opciones.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Deposito de Papeleria",
                        Description = "Documentacion de la web api del proyecto de Papeleria de Programacion 3. ",
                        License = new OpenApiLicense { Name = "Universidad ORT Uruguay." },
                        Contact = new OpenApiContact
                        {
                            Name = "with Angel Vaz & Rodrigo Cristaldo",
                            Email = "angelvs0123@gmail.com",
                        },
                        Version = "v1.0.0"
                    });
                }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
