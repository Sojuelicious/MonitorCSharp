using System;  // Necesario para las funcionalidades básicas de C# (como iniciar el programa). Sin esto, no podríamos hacer nada.
using System.Diagnostics;  // Importamos esto para poder interactuar con los procesos del sistema. ¡Es como tener un espía dentro del PC!
using System.Linq;  // Usamos LINQ para filtrar y seleccionar procesos de manera elegante. ¡Sin esto sería más difícil que organizar tu escritorio!
using System.Windows.Forms;  // Importamos esto porque estamos creando una interfaz gráfica (GUI). ¡Nada de pantallas negras de consola aquí!

namespace TaskManaggerFinalProject
{
    // Clase SoftwareInfo: Aquí es donde estamos en control de lo que está corriendo en tu PC. ¡Monitoreo total de software!
    public class SoftwareInfo
    {
        // Método que crea el panel donde veremos el software en ejecución
        public static Panel CrearPanelSoftware()
        {
            // Crear un panel donde se mostrará el software en ejecución
            Panel panelSoftware = new Panel
            {
                Location = new System.Drawing.Point(620, 70),  // Lo ubicamos junto al panel de hardware, no queremos que se peleen.
                Size = new System.Drawing.Size(600, 200),  // Tamaño adecuado para la información, no muy grande ni pequeña.
                AutoScroll = true,  // Si hay muchas aplicaciones, el panel tendrá barra de desplazamiento. ¡Nadie se queda fuera!
                BorderStyle = BorderStyle.FixedSingle  // Un borde simple para que todo se vea organizado.
            };

            // Crear el encabezado para el panel de software
            Label labelHeader = new Label
            {
                Text = "Software en Ejecución:",  // Título general de esta sección
                Location = new System.Drawing.Point(10, 10),  // Colocamos el encabezado en la parte superior
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),  // Fuente en negrita para que se vea claro
                AutoSize = true  // Aseguramos que el tamaño del label se ajuste al texto.
            };
            panelSoftware.Controls.Add(labelHeader);  // Añadimos el encabezado al panel.

            // Crear un label para listar las aplicaciones abiertas
            Label labelAplicaciones = new Label
            {
                Text = ObtenerAplicacionesAbiertas(),  // Llamamos al método que obtiene las aplicaciones abiertas
                Location = new System.Drawing.Point(10, 40),  // Colocamos el texto debajo del encabezado
                AutoSize = true  // Aseguramos que el texto se ajuste al tamaño del label
            };
            panelSoftware.Controls.Add(labelAplicaciones);  // Añadimos el label con las aplicaciones abiertas al panel.

            return panelSoftware;  // Devolvemos el panel con la lista de aplicaciones abiertas
        }

        // Método que obtiene las aplicaciones abiertas con una ventana principal
        private static string ObtenerAplicacionesAbiertas()
        {
            // Obtenemos los procesos que tienen una ventana principal (es decir, aplicaciones visibles)
            var aplicaciones = Process.GetProcesses()  // Obtenemos todos los procesos
                                      .Where(p => p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrEmpty(p.MainWindowTitle))  // Filtramos solo aquellos que tienen una ventana visible
                                      .Select(p => p.MainWindowTitle)  // Seleccionamos solo el título de la ventana principal de cada proceso
                                      .Distinct()  // Aseguramos que no haya repeticiones en la lista de aplicaciones
                                      .ToArray();  // Convertimos la lista de títulos a un array para que sea más fácil de manejar

            // Convertimos el array de aplicaciones a un solo string, con un salto de línea entre cada título
            return string.Join(Environment.NewLine, aplicaciones);
        }
    }
}
