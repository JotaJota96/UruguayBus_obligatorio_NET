using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TerminalAutogestion.Ventanas
{
    /// <summary>
    /// Lógica de interacción para WinIngresarDocumento.xaml
    /// </summary>
    public partial class WinIngresarDocumento : Window
    {
        private int viaje_id;
        private int paradaOrigen;
        private int paradaDestino;
        private int? asientoSeleccionado;

        public WinIngresarDocumento(int viaje_id, int paradaOrigen, int paradaDestino, int? asientoSeleccionado)
        {
            InitializeComponent();
            cmbTipoDocumento.Items.Add(TipoDocumento.CI);
            cmbTipoDocumento.Items.Add(TipoDocumento.OTROS);

            this.viaje_id = viaje_id;
            this.paradaOrigen = paradaOrigen;
            this.paradaDestino = paradaDestino;
            this.asientoSeleccionado = asientoSeleccionado;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            string documento = txtDocumento.Text;
            TipoDocumento td = (TipoDocumento) cmbTipoDocumento.SelectedItem;

            try
            {
                new WinIngresarDinero(viaje_id, paradaOrigen, paradaDestino, asientoSeleccionado, td, documento).ShowDialog();
                // si se completó el proceso o se debe volver a la pantalla de inicio
                if (MainWindow.cerrarEnCascada) Close();
            }
            catch (Exception ex)
            {
                MainWindow.excepcion = ex;
                MainWindow.cerrarEnCascada = true;
                Close();
            }
        }

        private void cmbTipoDocumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtDocumento.Text = "";
            HabilitarBoton();
        }

        private void txtDocumento_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9A-Za-z]+");
            e.Handled = regex.IsMatch(e.Text);
            HabilitarBoton();
        }

        private void txtDocumento_TextChanged(object sender, TextChangedEventArgs e)
        {
            HabilitarBoton();
        }

        private void HabilitarBoton(object sender = null, SelectionChangedEventArgs e = null)
        {
            btnSiguiente.IsEnabled = cmbTipoDocumento.SelectedItem != null && txtDocumento.Text.Length > 5;
        }

    }
}
