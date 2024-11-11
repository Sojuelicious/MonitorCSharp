using System;  // Necesario para obtener información sobre el entorno del sistema, como la versión de Windows.
using System.Windows.Forms;  // Necesario para trabajar con elementos de la interfaz gráfica (como etiquetas).

namespace TaskManaggerFinalProject
{
    // Clase WindowsInfo: Esta clase es responsable de obtener y mostrar la versión de Windows.
    public class WindowsInfo
    {
        // Método para crear una etiqueta que muestra la versión de Windows
        public static Label GetWindowsVersionLabel()
        {
            // Crear una etiqueta para mostrar la versión de Windows
            Label labelVersion = new Label();

            // Obtener la versión del sistema operativo usando la propiedad OSVersion de Environment
            string versionWindows = Environment.OSVersion.ToString();  // La propiedad OSVersion devuelve la versión de Windows como un string.

            // Configuramos el texto de la etiqueta para mostrar la versión de Windows
            labelVersion.Text = "Versión de Windows: " + versionWindows;

            // Establecer el estilo de la etiqueta (fuente y tamaño)
            labelVersion.Font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold);  // Fuente Arial, tamaño 20, negrita
            labelVersion.AutoSize = true;  // Ajusta automáticamente el tamaño de la etiqueta según el texto.

            // Posicionar la etiqueta en la esquina superior izquierda de la ventana
            labelVersion.Location = new System.Drawing.Point(10, 10);

            // Devolver la etiqueta para que pueda ser añadida a un formulario o panel
            return labelVersion;
        }
    }
}
