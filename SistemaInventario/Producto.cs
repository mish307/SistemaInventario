using System;

namespace SistemaInventario
{
    public class Producto
    {
        public string Nombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }

        // Este truco permite que la Lista de la pantalla muestre el texto bonito automáticamente
        public override string ToString()
        {
            return $"📦 {Nombre} | Stock: {Cantidad}";
        }
    }
}