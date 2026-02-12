# Solución prueba técnica Chubb

## Aspectos Técnicos

- El solución se organiza de las siguiente manera:
  
  - ChubbReto.Domain: Contiene la entidades de dominio y la abastracciones del repositorio.
  - ChubbReto.Application: Está estructurado en corte vertical para mejor escalabilidad de features por carpetas, dentro de estos las interfaces de servicios, implementación de servicios y DTOs y objetos compartidos por las diferentes features. Se implementa el Patrón de Servicios y Patrón de resultado para un mejor manejo de errores y excepciones. Los servicios implementan las validacioens de negocio.
  - ChubbReto.Infraestructure: Contiene la implementación de Patrón repositorio indicados por el dominio. Los repositorios están implementados con Dapper.
  - ChubbReto.Web: Contiene el Front desarrollado en MVC(Modelos, vistas y controladores) con pagos Razor(.cshtml). En esta capa existen vaidaciones a nivel de interfaz de usuario. Aqui se configura la inyección de dependencias. 

## Instrucciones de instalación

- Descargar el repositorio en maquina local.
- Abrir la solución ChubbReto.sln y restaurar los paquetes nuget.
- Establecer ChubbReto.Web como proyecto de inicio si no lo estuviera.
- Ejecutar el script de base de datos que se encuentra en la carpeta /Database y ejecutar el archivo ChubbReto-Data.sql.
- En el archivo web.config de ChubbReto.Web, buscar la llave DefaultConnection y cambiar el valor de connectionString por los datos del su sql local, reemplazando los datos entre corchetes dentro del conexión (Server=[instancia];Database=CHUBB_RETO;User Id=[usuario];Password=[password];TrustServerCertificate=True;). 
- Antes de ejecutar el proyecto limipiar la solución (Menú: Build > Build Clean Solución) y compilar (Menú: Build > Build Solution).

## Instrucciones de usuario

- La solución cuanta con 2 menús: Libros y autores.
- Cada menú, contiene la lista de libros y autores que hay en base de datos.
- Cada listado cuanta con un botón para Registrar un Libros y Autor respectivamente.
- Al presionar cada uno de los botones se accede al formulario de registro.

## Notas

- La solución está implementada en .NET Framework 4.7.2.
- La configuración de máximo de libros permitidos por autor en el Web.Config buscarla por la llave "MaxBooksPerAuthor".
