# Proyecto Papelería

Este proyecto es una solución para gestionar las ventas y el inventario en una tienda de papelería. Está compuesto por dos aplicaciones principales:

- **Papeleria.Web**: Para gestionar el catálogo de productos y las ventas.
- **DepositoPapeleria.Web**: Para gestionar el inventario, los artículos y los movimientos de stock.

## Tecnologías utilizadas

- **Lenguajes**: C#, HTML, CSS, JavaScript
- **Frameworks**: ASP.NET Core, MVC
- **Base de datos**: SQL Server
- **Otras herramientas**: Visual Studio, Git

## Estructura del proyecto

La estructura del proyecto se compone de varias carpetas, cada una encargada de una parte del sistema:

Proyecto/
├── Papeleria.Web/ # Gestión de ventas y catálogo de productos
│ ├── Controllers/ # Controladores para gestionar las vistas
│ ├── Models/ # Modelos de datos
│ ├── Views/ # Vistas para las páginas de la web
│ └── appsettings.json # Configuración de la aplicación
├── DepositoPapeleria.Web/ # Gestión de inventario y movimientos
│ ├── Controllers/ # Controladores para gestionar inventario
│ ├── Models/ # Modelos de inventarios, artículos, movimientos
│ ├── Views/ # Vistas para la gestión del inventario
│ └── appsettings.json # Configuración de la base de datos
└── README.md # Este archivo



## Instalación

### Requisitos previos

Antes de comenzar, asegúrate de tener instalados los siguientes programas:

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet) (versión 5.0 o superior).
- [Visual Studio](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/).
- SQL Server o base de datos configurada.

### Clonación del repositorio

Para clonar el repositorio en tu máquina local, usa el siguiente comando:

```bash
git clone https://github.com/tu-usuario/tu-repositorio.git
