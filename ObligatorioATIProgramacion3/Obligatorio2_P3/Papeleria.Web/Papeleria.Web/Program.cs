using Papeleria.AccesoDatos.EntityFramework.Repositorios;
using Papeleria.LogicaAplicacion.CasosDeUso.Administradores;
using Papeleria.LogicaAplicacion.CasosDeUso.Articulos;
using Papeleria.LogicaAplicacion.CasosDeUso.Clientes;
using Papeleria.LogicaAplicacion.CasosDeUso.Encriptacion;
using Papeleria.LogicaAplicacion.CasosDeUso.Pedidos;
using Papeleria.LogicaAplicacion.InterfacesCU.Administrador;
using Papeleria.LogicaAplicacion.InterfacesCU.Administradores;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCU.Encriptacion;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Inicializamos Repositorios
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();

            //Inicializamos Casos de Uso
            //CU Encriptacion
            builder.Services.AddScoped<IEncriptarPassword, EncriptarPasswordCU>();

            //CU Articulo
            builder.Services.AddScoped<IAgregarArticulo, AgregarArticuloCU>();
            builder.Services.AddScoped<IModificarArticulo, ModificarArticuloCU>();
            builder.Services.AddScoped<IObtenerArticulos, ObtenerArticulosCU>();
            builder.Services.AddScoped<IObtenerArticuloPorId, ObtenerArticuloPorIdCU>();

            //CU Usuario
            builder.Services.AddScoped<IAgregarUsuario, AgregarUsuarioCU>();
            builder.Services.AddScoped<IEliminarUsuario, EliminarUsuarioCU>();
            builder.Services.AddScoped<IModificarUsuario, ModificarUsuarioCU>();
            builder.Services.AddScoped<IObtenerUsuarios, ObtenerUsuariosCU>();
            builder.Services.AddScoped<IObtenerUsuarioPorId, ObtenerUsuarioPorIdCU>();
            
            builder.Services.AddScoped<IObtenerUsuarioPorCorreo,ObtenerUsuarioPorCorreoCU>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuarioCU>();
            //CU Pedido
            builder.Services.AddScoped<IAgregarPedido, AgregarPedidoCU>();
            builder.Services.AddScoped<IAnularPedido, AnularPedidoCU>();
            builder.Services.AddScoped<IObtenerPedidos, ObtenerPedidosCU>();
            builder.Services.AddScoped<IObtenerPedidoPorId, ObtenerPedidoPorIdCU>();
            builder.Services.AddScoped<IObtenerClientesMontoTotalMayorA, ObtenerClientesMontoTotalMayorACU>();

            //CU Cliente
            builder.Services.AddScoped<IObtenerClientes, ObtenerClientesCU>();
            builder.Services.AddScoped<IObtenerClientePorId, ObtenerClientePorIdCU>();
            builder.Services.AddScoped<IObtenerClientesPorTexto, ObtenerClientesPorTextoCU>();
            //builder.Services.AddScoped<IObtenerClientesTotalPedidosMayor, ObtenerClientesTotalPedidosMayorCU>(); //Migramos a Pedidos


            //AGREGAR SESSION
            /******************************** AGREGAMOS SERVICIO DE SESSION ********************************/

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(600); 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            /***********************************************************************************************/

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //USE SESSION
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
