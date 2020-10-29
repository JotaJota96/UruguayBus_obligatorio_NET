using Share.DTOs;
using Share.Entities;
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
    /// Lógica de interacción para WinSeleccionarViaje.xaml
    /// </summary>
    public partial class WinSeleccionarViaje : Window
    {
        SL_SoapClient serv = new SL_SoapClient();
        decimal precioParaElegirAsiento;
        bool permitirElegirAsiento = false;
        int asientoSeleccionado;
        ViajeDisponibleDTO viajeSeleccionado;

        public WinSeleccionarViaje(DateTime f, Parada po, Parada pd)
        {
            InitializeComponent();
            precioParaElegirAsiento = 100; // serv.PrecioParaElegirAsiento();
            dgViajes.ItemsSource = serv.ListarViajesDisponibles(f, po.id, pd.id);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            new WinIngresarDocumento().ShowDialog();
        }

        private void dgViajes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viajeSeleccionado = (ViajeDisponibleDTO) dgViajes.SelectedItem;
            dgAsientos.ItemsSource = AsientoDisponible.GenerarLista(viajeSeleccionado.asientos_disponibles);
            permitirElegirAsiento = viajeSeleccionado.precio >= precioParaElegirAsiento;
            dgAsientos.IsEnabled = permitirElegirAsiento;
            HabilitarBoton();
        }

        private void HabilitarBoton(object sender = null, SelectionChangedEventArgs e = null)
        {
            btnSiguiente.IsEnabled = dgViajes.SelectedItem != null &&
                (permitirElegirAsiento == false ||
                    (permitirElegirAsiento && dgAsientos.SelectedItem != null)
                );
        }

        private void dgAsientos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAsientos.SelectedItem == null)
            {
                asientoSeleccionado = 0;
            }
            else
            {
                asientoSeleccionado = ((AsientoDisponible)dgAsientos.SelectedItem).numero;
            }
            HabilitarBoton();
        }
    }

    // ***** ***** ***** ***** ***** ***** ***** ***** ***** ***** ***** 

    public class AsientoDisponible
    {
        public int numero { get; set; }
        public string descripcion { get; set; }

        public static ICollection<AsientoDisponible>  GenerarLista(ICollection<int> lst)
        {
            ICollection<AsientoDisponible> ret = new List<AsientoDisponible>();
            foreach (var item in lst)
            {
                ret.Add(new AsientoDisponible() { 
                    numero = item,
                    descripcion = AsientoDisponible.Descripcion(item),
                });
            }
            return ret;
        }

        private static string Descripcion(int n)
        {
            if (n == 2 || n == 3) return "Ventana";
            if (n < 1) return "Pasillo";
            return AsientoDisponible.Descripcion(n-4);
        }

    }
}