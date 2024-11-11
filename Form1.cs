using System;
using System.Windows.Forms;

namespace TaskManaggerFinalProject
{
    // Esta clase representa el formulario principal de la aplicación.
    // Hereda de la clase Form, que es una ventana de la interfaz gráfica en Windows Forms.
    public partial class Form1 : Form
    {
        // Constructor de la clase Form1.
        // Este método se llama cuando se crea una instancia de la ventana del formulario.
        public Form1()
        {
            InitializeComponent();  // Inicializa los componentes de la interfaz gráfica de usuario (botones, etiquetas, etc.)

            // Llamadas a los métodos para mostrar diversas informaciones en la ventana.
            MostrarVersionWindows();            // Muestra la versión de Windows en el formulario.
            MostrarHardwareInfo();              // Muestra la información del hardware.
            MostrarAplicacionesEnEjecucion();   // Muestra las aplicaciones que están en ejecución en el sistema.
            MostrarProcesosEnEjecucion();       // Muestra los procesos que se están ejecutando en el sistema.
            MostrarPerformaceMonitor();         // Muestra el monitoreo de rendimiento del sistema.
            MostrarConexionesRed();             // Muestra las conexiones de red activas en el sistema.

            // Establece el tamaño de la ventana principal del formulario.
            // Esto ajusta el alto para que haya espacio suficiente para mostrar toda la información.
            this.Size = new System.Drawing.Size(1300, 1000);
        }

        // Método para mostrar la versión de Windows en el formulario.
        // Llama a la clase WindowsInfo para obtener un control con la versión y lo agrega a los controles del formulario.
        private void MostrarVersionWindows()
        {
            // Llama al método GetWindowsVersionLabel de la clase WindowsInfo, que devuelve una etiqueta con la versión de Windows.
            Label labelVersion = WindowsInfo.GetWindowsVersionLabel();

            // Agrega la etiqueta con la versión de Windows al formulario.
            this.Controls.Add(labelVersion);
        }

        // Método para mostrar la información de hardware en el formulario.
        // Llama al método MostrarHardware de la clase HardwareInfo, que devuelve un panel con la información de hardware.
        private void MostrarHardwareInfo()
        {
            // Llama al método MostrarHardware de la clase HardwareInfo para obtener un panel con la información.
            Panel panelHardware = HardwareInfo.MostrarHardware();

            // Agrega el panel con la información del hardware al formulario.
            this.Controls.Add(panelHardware);
        }

        // Método para mostrar las aplicaciones en ejecución en el formulario.
        // Llama al método CrearPanelSoftware de la clase SoftwareInfo, que devuelve un panel con la lista de aplicaciones en ejecución.
        private void MostrarAplicacionesEnEjecucion()
        {
            // Llama al método CrearPanelSoftware de la clase SoftwareInfo para obtener el panel con las aplicaciones.
            Panel panelSoftware = SoftwareInfo.CrearPanelSoftware();

            // Agrega el panel de aplicaciones en ejecución al formulario.
            this.Controls.Add(panelSoftware);
        }

        // Método para mostrar los procesos en ejecución en el formulario.
        // Llama al método CrearPanelProcesos de la clase ProcessInfo, que devuelve un panel con los procesos activos.
        private void MostrarProcesosEnEjecucion()
        {
            // Llama al método CrearPanelProcesos de la clase ProcessInfo para obtener un panel con los procesos.
            Panel panelProcesos = ProcessInfo.CrearPanelProcesos();

            // Agrega el panel con los procesos en ejecución al formulario.
            this.Controls.Add(panelProcesos);
        }

        // Método para mostrar el monitoreo de rendimiento en el formulario.
        // Llama al método CrearPanelMonitoreo de la clase PerformanceMonitor, que devuelve un panel con los datos de rendimiento.
        private void MostrarPerformaceMonitor()
        {
            // Llama al método CrearPanelMonitoreo de la clase PerformanceMonitor para obtener un panel con el monitoreo de rendimiento.
            Panel panelMonitoreo = PerformanceMonitor.CrearPanelMonitoreo();

            // Agrega el panel de monitoreo de rendimiento al formulario.
            this.Controls.Add(panelMonitoreo);
        }

        // Método para mostrar las conexiones de red activas en el formulario.
        // Llama al método CrearPanelConexiones de la clase NetworkConnections, que devuelve un panel con la información de las conexiones de red.
        private void MostrarConexionesRed()
        {
            // Llama al método CrearPanelConexiones de la clase NetworkConnections para obtener el panel con las conexiones de red.
            Panel panelRed = NetworkConnections.CrearPanelConexiones();

            // Agrega el panel con las conexiones de red al formulario.
            this.Controls.Add(panelRed);
        }
    }
}
