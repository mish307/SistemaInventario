using System.Windows;
using System.Windows.Controls;

namespace SistemaInventario
{
    public partial class MainWindow : Window
    {
        // 1. Instanciamos nuestro Cerebro/Controlador
        private GestorInventario gestor = new GestorInventario();
        private Producto productoSeleccionado = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        // ==========================================
        // PESTAÑA 1: AGREGAR (CREATE)
        // ==========================================
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            // Validamos que los datos estén correctos
            if (string.IsNullOrWhiteSpace(txtNombreAgregar.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtCantidadAgregar.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("Cantidad inválida. Ingresa un número entero positivo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Creamos y guardamos el producto
            Producto nuevo = new Producto
            {
                Nombre = txtNombreAgregar.Text.Trim(),
                Cantidad = cantidad
            };

            gestor.AgregarProducto(nuevo);

            ActualizarListasVisuales();

            // Limpiamos las cajas de la Pestaña 1
            txtNombreAgregar.Clear();
            txtCantidadAgregar.Clear();
            MessageBox.Show("Producto guardado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // ==========================================
        // PESTAÑA 3: GESTIONAR (UPDATE / DELETE)
        // ==========================================
        private void LstGestionar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Al hacer clic en la lista, subimos los datos a las cajitas de editar
            if (lstGestionar.SelectedItem != null)
            {
                productoSeleccionado = (Producto)lstGestionar.SelectedItem;
                txtNombreEditar.Text = productoSeleccionado.Nombre;
                txtCantidadEditar.Text = productoSeleccionado.Cantidad.ToString();
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un producto primero.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validamos los datos de las cajas de edición
            if (string.IsNullOrWhiteSpace(txtNombreEditar.Text) || !int.TryParse(txtCantidadEditar.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("Datos inválidos para actualizar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Actualizamos mediante el gestor
            gestor.ActualizarProducto(productoSeleccionado, txtNombreEditar.Text.Trim(), cantidad);
            ActualizarListasVisuales();
            LimpiarFormularioGestionar();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un producto primero.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult respuesta = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes)
            {
                gestor.EliminarProducto(productoSeleccionado);
                ActualizarListasVisuales();
                LimpiarFormularioGestionar();
            }
        }

        // ==========================================
        // MÉTODOS DE APOYO
        // ==========================================
        private void ActualizarListasVisuales()
        {
            // Actualizamos la lista de la pestaña "Ver"
            lstSoloLectura.ItemsSource = null;
            lstSoloLectura.ItemsSource = gestor.ObtenerTodos();

            // Actualizamos la lista de la pestaña "Gestionar"
            lstGestionar.ItemsSource = null;
            lstGestionar.ItemsSource = gestor.ObtenerTodos();
        }

        private void LimpiarFormularioGestionar()
        {
            // Limpiamos las cajas de la Pestaña 3
            txtNombreEditar.Clear();
            txtCantidadEditar.Clear();
            lstGestionar.SelectedItem = null;
            productoSeleccionado = null;
        }
    }
}