# Prueba Técnica para Desarrollador .NET

**Duración máxima:** 1 día

## Requerimientos

- **Lenguaje:** C#
- **Base de datos:** SQL Server
- **Back-End:** .NET Framework 4.5 o mayor
- **Front-End:** .NET Framework 4.5 o mayor (Razor)

## Objetivo

Desarrollar componentes en .NET para:

- Registrar libros:
  - Título (*)
  - Año (*)
  - Género 
  - Número de páginas 
  - Autor (*)

- Registrar autores:
  - Nombre completo (*)
  - Fecha de nacimiento (*)
  - Ciudad de procedencia
  - Correo electrónico (*)

## Reglas de Negocio

- Todos los campos marcados con (*) son obligatorios.
- Garantizar la integridad de la información.
- Controlar el número máximo de libros permitidos.
- Si se supera el máximo de libros, lanzar excepción con mensaje:
  **“No es posible registrar el libro, se alcanzó el máximo permitido.”**
- Si el autor no existe al registrar un libro, responder con:
  **“El autor no está registrado”.**

## Aspectos Técnicos

- Estructura de paquetes:
  - Entidades
  - DTOs
  - Interfaces
  - Servicios (implementación)
  - Controladores
  - Excepciones
- Usar inyección de dependencias.
- Aplicar buenas prácticas de desarrollo y código legible.

## Entregables

- Código fuente completo y funcional.
- Script de base de datos (creación de tablas y datos de prueba).
- Instrucciones para ejecutar el proyecto.

## Sugerencia de Cronograma (1 día)

| Hora | Actividad |
|------|-----------|
| 1    | Análisis de requerimientos y diseño de la base de datos |
| 2-3  | Implementación de entidades, DTOs e interfaces |
| 4-5  | Desarrollo de servicios y lógica de negocio |
| 6    | Creación de controladores y excepciones |
| 7    | Desarrollo del Front-End básico |
| 8    | Pruebas, ajustes y documentación |

---

¡Éxito en tu desarrollo!
