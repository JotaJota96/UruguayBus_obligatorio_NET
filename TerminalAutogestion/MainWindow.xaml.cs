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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TerminalAutogestion.Ventanas;

namespace TerminalAutogestion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool cerrarEnCascada = false;
        public static Exception excepcion = null;

        public MainWindow()
        {
            InitializeComponent();
            lbError.Visibility = Visibility.Hidden;
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.cerrarEnCascada = false;
                new WinIngresarDatosViaje().ShowDialog();
                if (MainWindow.excepcion != null) throw excepcion;
            }
            catch (Exception)
            {
                // creo un Timer para ocultar el mensaje de error despues de unos segundos
                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 4);
                dispatcherTimer.Start();

                lbError.Visibility = Visibility.Visible;
            }
        }

        // evento de Timer para ocultar mensaje
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lbError.Visibility = Visibility.Hidden;
        }
    }
}
