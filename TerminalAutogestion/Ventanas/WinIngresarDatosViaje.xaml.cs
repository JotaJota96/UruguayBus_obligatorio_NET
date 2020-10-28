using System;
using System.Collections.Generic;
using System.Data;
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
            for (int i = 0; i < 20; i++)
            {
                DateTime fecha = DateTime.Today; 
                fecha = fecha.AddDays(i);
                lstFechas.Items.Add(String.Format("{0:dd-MM-yyyy}", fecha));
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            new WinSeleccionarViaje().ShowDialog();
        }
    }
}
