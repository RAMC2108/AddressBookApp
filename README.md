# Contact API

## Descripción
Esta es una API REST en .NET 8 para la gestión de contactos. Permite listar, obtener y eliminar contactos almacenados en una base de datos o archivo JSON.

## Tecnologías
- .NET 8
- ASP.NET Core
- C#
- JSON

## Endpoints

### Obtener todos los contactos
**GET /api/contact**

#### Respuesta
- **200 OK**: Devuelve un array JSON de contactos ordenados por nombre.
- **Ejemplo de respuesta:**

```json
[
  {
    "id": "ac2668fd-f4b5-4175-8956-d8f1920f1324",
    "name": "Blaze Dare",
    "phone": "842.152.8355",
    "addressLines": [
      "4438 Korey Centers",
      "Lake Carolannetown",
      "Bangladesh"
    ]
  }
]
```

#### Filtro por frase
Puedes filtrar por nombre utilizando el query param `phrase`, ignorando mayúsculas/minúsculas.
- **Ejemplo:** `GET /api/contact?phrase=zA`

---

### Obtener un contacto por ID
**GET /api/contact/{id}**

#### Respuesta
- **200 OK**: Devuelve el contacto con el ID solicitado.
- **404 Not Found**: Si el contacto no existe.

---

### Eliminar un contacto
**DELETE /api/contact/{id}**

#### Respuesta
- **204 No Content**: Contacto eliminado correctamente.
- **404 Not Found**: Si el contacto no existe.

---

## Manejo de Errores
| Código | Significado |
|--------|------------|
| 400 Bad Request | Si el `phrase` está vacío. |
| 404 Not Found | Si el ID no existe. |
| 405 Method Not Allowed | Si se usa un método HTTP no permitido. |

## Ejecución
1. Clonar el repositorio.
2. Restaurar paquetes con `dotnet restore`.
3. Ejecutar con `dotnet run`.

## Contacto
Autor: Rodrigo Hu

