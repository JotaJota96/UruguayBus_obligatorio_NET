using Share.Entities;
using Share.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Activation.Configuration;
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
    /// Lógica de interacción para WinIngresarDatosViaje.xaml
    /// </summary>
    public partial class WinIngresarDatosViaje : Window
    {
        public WinIngresarDatosViaje()
        {
            InitializeComponent();
            SL_SoapClient serv = new SL_SoapClient();

            // carga lista de fechas
            for (int i = 0; i < 20; i++)
            {
                DateTime fecha = DateTime.Today.AddDays(i);
                DiaSemana dia = (DiaSemana)fecha.DayOfWeek;
                FechaItem fi = new FechaItem()
                {
                    fecha = fecha,
                    texto = String.Format("{0:dd-MM-yyyy}", fecha) + " (" + dia.ToString().ToLower() + ")",
                };
                lstFechas.Items.Add(fi);
                //lstFechas.Items.Add(String.Format("{0:dd-MM-yyyy}", fecha) + " (" + dia.ToString().ToLower() + ")");
            }


            // carga lista origen y destino
            ICollection<Parada> paradas = serv.ListarParadas();
            foreach (var item in paradas)
            {
                lstOrigen.Items.Add(item);
                lstDestino.Items.Add(item);
            }



        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            DateTime f = ((FechaItem)lstFechas.SelectedItem).fecha;
            Parada po = (Parada) lstOrigen.SelectedItem;
            Parada pd = (Parada) lstDestino.SelectedItem;
            new WinSeleccionarViaje(f, po, pd).ShowDialog();
        }

        private void lstOrigen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstDestino.Items.Clear();
            foreach (var item in lstOrigen.Items)
            {
                lstDestino.Items.Add(item);
            }
             lstDestino.Items.Remove(lstOrigen.SelectedItem);
            HabilitarBoton();
        }

        private void HabilitarBoton(object sender = null, SelectionChangedEventArgs e = null)
        {
            btnSiguiente.IsEnabled = lstFechas.SelectedItem != null && lstOrigen.SelectedItem != null && lstDestino.SelectedItem != null;
        }
    }

    public class FechaItem
    {
        public DateTime fecha { get; set; }
        public string texto { get; set; }
    }
}
