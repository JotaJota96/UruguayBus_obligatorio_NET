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
            ServiceSOAP.SL_SoapClient servicio = new ServiceSOAP.SL_SoapClient();

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

            // ** borrar esto ****
            ICollection<Parada> paradas = new List<Parada>();
            for (int i = 1; i <= 10; i++)
            {
                paradas.Add(new Parada() { id = i, nombre = "parada " + i });
            }
            // *******************

            // carga lista origen
            // carga lista destino
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

    }

    public class FechaItem
    {
        public DateTime fecha { get; set; }
        public string texto { get; set; }
    }
}
