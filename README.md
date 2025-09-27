# TodoList API

Una API RESTful sencilla para gestionar tareas (to-do), desarrollada con ASP.NET Core.

## Descripción

TodoList API es una aplicación backend que permite crear, obtener y actualizar tareas. Está construida utilizando ASP.NET Core y SQL Server, implementando una arquitectura de servicios y acceso a datos mediante procedimientos almacenados.

## Tecnologías

- ASP.NET Core 8.0
- SQL Server
- Swagger/OpenAPI

## Estructura del Proyecto

- **Controllers**: Contiene el controlador de tareas que maneja las solicitudes HTTP.
- **Models**: Define las clases de dominio y los DTOs utilizados en la aplicación.
- **Services**: Implementa la lógica de negocio y el acceso a datos.
- **Helpers**: Contiene clases auxiliares, como el helper de conexión a base de datos.
- **Scripts**: Contiene scripts SQL para la creación de la base de datos y procedimientos almacenados.

## Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/tasks | Obtiene todas las tareas |
| GET | /api/tasks/{id} | Obtiene una tarea por su ID |
| POST | /api/tasks | Crea una nueva tarea |
| PUT | /api/tasks/{id} | Actualiza una tarea existente |

## Modelo de Datos

### Tarea (Task)

| Campo | Tipo | Descripción |
|-------|------|-------------|
| Id | int | Identificador único de la tarea |
| Title | string | Título o descripción de la tarea |
| Completed | boolean | Estado de la tarea (completada/pendiente) |
| CreatedAt | datetime | Fecha de creación de la tarea |

## Configuración de Base de Datos

1. Crear una base de datos llamada `toDoList` en SQL Server.
2. Ejecutar los scripts SQL en el siguiente orden:
   - `scripts/DDL/create_table_task.sql` - Crea la tabla de tareas
   - `scripts/DML/create_sp_STasks.sql` - Procedimiento para obtener todas las tareas
   - `scripts/DML/create_sp_STaskById.sql` - Procedimiento para obtener tarea por ID
   - `scripts/DML/create_sp_ITask.sql` - Procedimiento para insertar tarea
   - `scripts/DML/create_sp_UTask.sql` - Procedimiento para actualizar tarea

## Configuración de la Aplicación

Asegúrate de configurar la cadena de conexión en el archivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tu-servidor;Database=toDoList;User Id=tu-usuario;Password=tu-contraseña;TrustServerCertificate=True"
  }
}
```

## Ejecución del Proyecto

1. Clona el repositorio
2. Configura la base de datos y la cadena de conexión
3. Ejecuta el proyecto
   ```
   dotnet run
   ```
4. Accede a la documentación Swagger en `https://localhost:7042/swagger`

## Documentación de la API

La documentación completa de la API está disponible a través de Swagger UI, que se puede acceder al ejecutar la aplicación y navegar a la ruta `/swagger`.
