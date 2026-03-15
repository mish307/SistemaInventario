using System.Collections.Generic;

namespace SistemaInventario
{
    public class GestorInventario
    {
        // La memoria interna (privada, para que nadie la modifique por error)
        private List<Producto> inventario;

        public GestorInventario()
        {
            inventario = new List<Producto>();
        }

        // --- C: Create ---
        public void AgregarProducto(Producto nuevo)
        {
            inventario.Add(nuevo);
        }

        // --- R: Read ---
        public List<Producto> ObtenerTodos()
        {
            return inventario;
        }

        // --- U: Update ---
        public void ActualizarProducto(Producto producto, string nuevoNombre, int nuevaCantidad)
        {
            producto.Nombre = nuevoNombre;
            producto.Cantidad = nuevaCantidad;
        }

        // --- D: Delete ---
        public void EliminarProducto(Producto producto)
        {
            inventario.Remove(producto);
        }
    }
}