# Proyecto XYZBoutique

## Descripción
Este proyecto es una aplicación de Boutique que gestiona pedidos. A continuación, se detallan los principales endpoints proporcionados por la API.

## Endpoints

### Crear Pedido
- **Ruta:** `/api/Pedido/Create` (POST)
- **Descripción:** Crea un nuevo pedido en el sistema.
- **Payload de solicitud:** [Detalles del Pedido]

### Actualizar Estado del Pedido
- **Ruta:** `/api/Pedido/UpdateEstadoPedido` (POST)
- **Descripción:** Actualiza el estado de un pedido existente en el sistema.
- **Payload de solicitud:** [Detalles del Pedido con Estado Actualizado]

### Obtener Pedidos con Filtro
- **Ruta:** `/api/Pedido/PedidosWithFilter` (GET)
- **Descripción:** Obtiene una lista de pedidos filtrada según los criterios especificados.
- **Parámetros de consulta:** [Criterios de Filtro]

### Obtener Productos por SKU o Nombre
- **Ruta:** `/api/Producto/ProductosBySkuOrNombre` (POST)
- **Descripción:** Obtiene productos que coinciden con el SKU o el nombre proporcionado.
- **Payload de solicitud:** [Criterios de Búsqueda de Productos]

### Autenticar Usuario
- **Ruta:** `/api/Usuario/Authenticate` (POST)
- **Descripción:** Autentica a un usuario y devuelve un token de acceso.
- **Payload de solicitud:** [Credenciales de Usuario]

### Obtener Usuarios por Rol
- **Ruta:** `/api/Usuario/UsuariosByRol/{idRol}` (GET)
- **Descripción:** Obtiene una lista de usuarios filtrada por el ID del rol.
- **Parámetros de ruta:** [ID del Rol]

## Notas Importantes
- Todos los endpoints que requieren autenticación deben incluir un token de acceso válido en la cabecera de la solicitud.
- Consulta la documentación detallada de cada endpoint para obtener información específica sobre los payloads y los parámetros necesarios.
- Las credenciales para obtener el token se obtienden desde [Credenciales de Usuario].
- Servidor de despliegue para probar endpoints: 181.66.17.25

[Detalles del Pedido]: #detalles-del-pedido
[Detalles del Pedido con Estado Actualizado]: #detalles-del-pedido-con-estado-actualizado
[Criterios de Filtro]: #criterios-de-filtro
[Criterios de Búsqueda de Productos]: #criterios-de-búsqueda-de-productos
[Credenciales de Usuario]: #credenciales-de-usuario
[ID del Rol]: #id-del-rol

## Detalles del Pedido
Ejemplo de Solicitud  
(Request)
```json
{
  "idUsuarioSolicitante": 1,
  "repartidor": "jesus cuadros",
  "detallePedido": [
    {
      "idProducto": 1,
      "cantidad": 1,
      "precio": 99.9,
      "total": 99.9
    }
  ]
}
```
(Response)
```json
{
  "isSuccess": true,
  "data": true,
  "totalRecords": null,
  "message": "Se registró correctamente.",
  "errors": null
}
```
## Detalles del Pedido con Estado Actualizado
Ejemplo de Solicitud  
(Request)
```json
{
  "idPedido": 1,
  "idEstadoPedido": 1
}
```
(Response)
```json
{
  "isSuccess": true,
  "data": true,
  "totalRecords": null,
  "message": "Se registró correctamente.",
  "errors": null
}
```
## Criterios de Filtro
(Request)   
``` 
Path: /api/Pedido/PedidosWithFilter  
Query: ?nroPedido=0000001    
``` 
(Response)
```json
{
  "isSuccess": true,
  "data": [
    {
      "idPedido": 1,
      "nroPedido": "0000001",
      "fechaPedido": "2024-01-07T18:32:57.793",
      "fechaRecepcion": null,
      "fechaDespacho": null,
      "fechaEntrega": null,
      "usuarioSolicitante": "Juan Pérez",
      "repartidor": "jesus cuadros",
      "idEstadoPedido": 2,
      "estadoPedido": "En proceso",
      "fechaRegistro": "2024-01-07T10:17:16.873",
      "detallePedido": [
        {
          "idDetallePedido": 1,
          "producto": "Almohada Cebra Viscodream",
          "cantidad": 1,
          "precio": 99.9,
          "total": 99.9
        }
      ]
    }
  ],
  "totalRecords": 1,
  "message": "Consulta exitosa",
  "errors": null
}
```
## Criterios de Búsqueda de Productos
(Request)   
``` json
{
  "nombre": "Almohada ",
  "sku": ""
}
```
    
(Response)
```json
{
  "isSuccess": true,
  "data": [
    {
      "idProducto": 1,
      "nombre": "Almohada Cebra Viscodream",
      "sku": "ALM-CEB-VIS",
      "tipo": "Artículos para el Hogar",
      "etiquetas": "Algodon;Verde;Mediano;Vintage;",
      "precio": 99.9,
      "unidadMedida": "Unidad",
      "stock": 20,
      "fechaRegistro": "2024-01-07T09:47:12.107"
    }
  ],
  "totalRecords": 1,
  "message": "Consulta exitosa.",
  "errors": null
}
```

## Credenciales de Usuario
(Request)   
``` json
{
  "codigoTrabajador": "jperez",
  "clave": "juan123"
}
```
    
(Response)
```json
{
  "isSuccess": true,
  "data": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJKUEVSRVoiLCJ1bmlxdWVfbmFtZSI6IjEiLCJqdGkiOiJlOGNjNWYxYy0wZmY4LTQ4NTktOGQ0ZS0zMDU4M2NkZDA4ZjUiLCJpYXQiOiIyZDFhNWQ1MS00ZjA5LTQ3ZmUtYjhkYi1mYjJjYTA1OTU1ZmEiLCJuYmYiOjE3MDQ2NzA4NzgsImV4cCI6MTcwNDY5OTY3OCwiaXNzIjoiaHR0cDovL3NpcnRlY2guY29tLnBlIiwiYXVkIjoiaHR0cDovL3NpcnRlY2guY29tLnBlIn0.1zqtooNIF5MyGVxYRkaTI5XjKqiZ0SBwdZ2gSEUuQw8",
  "totalRecords": null,
  "message": "Token generado.",
  "errors": null
}
```
## ID del Rol
(Request)   
``` 
Path: /api/Usuario/UsusariosByRol/4
```
    
(Response)
```json
{
  "isSuccess": true,
  "data": [
    {
      "idUsuario": 4,
      "codigoTrabajador": "AMARTINEZ",
      "nombreCompleto": "Ana Martínez",
      "correo": "ana.martinez@email.com",
      "telefono": "654321098",
      "puesto": "Repartidor Principal",
      "rol": "Repartidor",
      "fechaRegistro": "2024-01-07T09:47:12.073"
    },
    {
      "idUsuario": 8,
      "codigoTrabajador": "RGOMEZ",
      "nombreCompleto": "Roberto Gómez",
      "correo": "roberto.gomez@email.com",
      "telefono": "333222111",
      "puesto": "Repartidor Asociado",
      "rol": "Repartidor",
      "fechaRegistro": "2024-01-07T11:35:16.333"
    }
  ],
  "totalRecords": 2,
  "message": "Consulta exitosa.",
  "errors": null
}
```
