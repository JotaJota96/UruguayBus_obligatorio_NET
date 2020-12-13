using Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TerminalAutogestion.ServiceSOAP;

namespace TerminalAutogestion.Ventanas
{
    /// <summary>
    /// Lógica de interacción para WinIngresarDinero.xaml
    /// </summary>
    public partial class WinIngresarDinero : Window
    {
        SL_SoapClient serv = new SL_SoapClient(Constantes.SOAP_SERVICE_URL);

        private int viaje_id;
        private int paradaOrigen;
        private int paradaDestino;
        private int? asientoSeleccionado;
        private TipoDocumento tipoDoc;
        private string documento;

        public WinIngresarDinero(int viaje_id, int paradaOrigen, int paradaDestino, int? asientoSeleccionado, TipoDocumento td, string documento)
        {
            InitializeComponent();
            this.viaje_id = viaje_id;
            this.paradaOrigen = paradaOrigen;
            this.paradaDestino = paradaDestino;
            this.asientoSeleccionado = asientoSeleccionado;
            this.tipoDoc = td;
            this.documento = documento;
        }

        private void reservar()
        {
            try
            {
                serv.ReservarPasaje(viaje_id, paradaOrigen, paradaDestino, documento, tipoDoc, asientoSeleccionado);
            }
            catch (Exception ex)
            {
                MainWindow.excepcion = ex;
                MainWindow.cerrarEnCascada = true;
                Close();
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reservar();
                // cerrar todas las ventanas para volver al inicio
                MainWindow.cerrarEnCascada = true;
                Close();
            }
            catch (Exception ex)
            {
                MainWindow.excepcion = ex;
                MainWindow.cerrarEnCascada = true;
                Close();
            }
        }
    }
}
