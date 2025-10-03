# 🛒 Sistema de Procesamiento de Datos de Ventas

Sistema ETL desarrollado en C# .NET para procesar y cargar datos de ventas desde archivos CSV a SQL Server usando Entity Framework Core.

## 🏗️ Arquitectura
CSV → Lectura → Limpieza → Carga → BD SQL Server

## 🗃️ Modelo de Datos

**Entidades Principales:**
- `Clientes` - Información de clientes
- `Productos` - Catálogo de productos  
- `Ordenes` - Cabecera de pedidos
- `DetalleOrdenes` - Líneas de pedido (clave compuesta)

**Relaciones:**
- Clientes 1 → N Ordenes
- Ordenes 1 → N DetalleOrdenes
- Productos 1 → N DetalleOrdenes

## ⚡ Características

- **Procesamiento por Lotes**: Inserciones en grupos de 1000 registros
- **Limpieza Automática**: Filtrado de datos inválidos y duplicados
- **Cálculo de Totales**: Cálculo automático de totales de órdenes
- **Validación Completa**: Verificación de integridad de datos

## 🚀 Uso Rápido

```csharp
// 1. Leer datos CSV
var productos = new ProductsService("products.csv").ReadProducts();

// 2. Limpiar datos
var productosLimpios = new ProcesamientoService(conexion).LimpiarProductos(productos);

// 3. Cargar a BD
new LoadDataService(conexion).LoadProducts(productosLimpios);
