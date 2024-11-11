using System;  // Necesario para todo lo básico de C#; si no lo importas, el programa no sabría cómo empezar. Básicamente, el 'System' es el corazón del programa.
using System.Diagnostics;  // Traemos esto para ejecutar procesos del sistema, como ejecutar comandos de la terminal, que es lo que hacemos con "netstat". ¡Lo usamos para espiar las conexiones de red!
using System.Text;  // Aquí encontramos la clase 'StringBuilder', que usamos para construir el texto de manera eficiente. ¡Porque queremos que las conexiones de red no nos hagan sudar con texto largo!
using System.Windows.Forms;  // Esta es la librería que necesitamos para crear y gestionar interfaces gráficas de usuario (GUI), como las ventanas que ves cuando usas programas. Aquí es donde se arma todo el escenario.

namespace TaskManaggerFinalProject
{
    // Clase NetworkConnections, nuestro "detective privado" para todas las conexiones de red activas. ¡Haremos que tu PC hable!
    public static class NetworkConnections
    {
        // Este es el método principal que crea el panel donde mostramos las conexiones de red. Es como poner un tablero de control en tu sala de operaciones.
        public static Panel CrearPanelConexiones()
        {
            // Crear un panel para mostrar las conexiones de red
            Panel panelRed = new Panel
            {
                Location = new System.Drawing.Point(10, 595),  // Ubicación en el formulario, justo debajo del panel de procesos. ¡Nada de dejar espacios vacíos!
                Size = new System.Drawing.Size(600, 300),  // El tamaño del panel, ajustado para que quepa todo, ¡pero sin hacerle sombra al resto!
                AutoScroll = true,  // Si la información es demasiado larga, que el panel tenga barra de desplazamiento. ¡Nunca nos gusta ver la información fuera de control!
                BorderStyle = BorderStyle.FixedSingle  // Un borde simple alrededor del panel para darle un toque de elegancia.
            };

            // Crear el encabezado para las conexiones de red. ¡Porque todo tablero de control necesita un título espectacular!
            Label labelTitulo = new Label
            {
                Text = "Conexiones de Red",  // El nombre que aparecerá en la parte superior del panel.
                Location = new System.Drawing.Point(10, 10),  // La ubicación del título en el panel.
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),  // Font con un toque profesional y audaz.
                AutoSize = true  // Ajuste automático del tamaño del texto para que no se desborde.
            };
            panelRed.Controls.Add(labelTitulo);  // Añadir el título al panel. ¡Ahora sí, con estilo!

            // Crear un encabezado con nombres de columnas. ¡Para que todo quede bien organizado y fácil de leer!
            Label labelHeader = new Label
            {
                Text = "RED ACTIVA".PadRight(30) + "ENTRANTES".PadRight(30) + "SALIENTES".PadRight(20),  // Espaciado perfecto para que todo se vea alineado.
                Location = new System.Drawing.Point(10, 40),  // Ubicación de las columnas en el panel.
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),  // Fuente de las columnas, para que se vea como un informe de la CIA.
                AutoSize = true  // Ajuste automático para evitar desbordes.
            };
            panelRed.Controls.Add(labelHeader);  // Añadir las cabeceras al panel.

            // Crear una etiqueta donde se mostrarán las conexiones de red activas. ¡La información que realmente nos interesa!
            Label labelConexiones = new Label
            {
                Text = ObtenerConexionesDeRed(),  // Aquí es donde llamamos al método para obtener las conexiones activas.
                Location = new System.Drawing.Point(10, 70),  // La ubicación de las conexiones en el panel.
                AutoSize = true  // Dejamos que el tamaño de la etiqueta se ajuste al contenido.
            };
            panelRed.Controls.Add(labelConexiones);  // Añadir la etiqueta con las conexiones al panel.

            return panelRed;  // Devolver el panel con toda la información lista para ser visualizada.
        }

        // Método privado que obtiene las conexiones de red activas.
        // ¡Este es el comando "netstat" de la línea de comandos! Nos va a dar toda la información que necesitamos para saber qué está pasando en la red.
        private static string ObtenerConexionesDeRed()
        {
            StringBuilder output = new StringBuilder();  // Creamos un StringBuilder para ir acumulando la información de las conexiones.

            // Ejecutar el comando "netstat" y capturar la salida
            using (Process process = new Process())  // Creamos un proceso para ejecutar el comando en la terminal.
            {
                process.StartInfo.FileName = "cmd.exe";  // Vamos a usar cmd.exe, porque es el programa de la terminal que conocemos y amamos.
                process.StartInfo.Arguments = "/c netstat -an";  // Le pasamos el comando "netstat -an" para obtener las conexiones activas de la red.
                process.StartInfo.RedirectStandardOutput = true;  // Queremos obtener la salida del proceso, porque si no, sería como pedirle a alguien que hable sin escuchar.
                process.StartInfo.UseShellExecute = false;  // No necesitamos ejecutar el proceso con la interfaz de usuario del shell.
                process.StartInfo.CreateNoWindow = true;  // No queremos ver la ventana de la terminal. ¡Esconde todo, como un ninja!
                process.Start();  // Ejecutamos el proceso.

                string line;
                // Leemos las líneas de la salida del comando "netstat"
                while ((line = process.StandardOutput.ReadLine()) != null)
                {
                    // Filtramos las líneas que contienen información relevante de las conexiones activas
                    if (line.Contains("TCP") || line.Contains("UDP"))  // Solo nos interesan las conexiones TCP y UDP. ¡Eso es lo que realmente usamos!
                    {
                        string[] columns = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);  // Dividimos la línea por espacios, para separar las columnas.

                        if (columns.Length >= 4)  // Aseguramos que haya suficiente información para mostrar (dirección local, remota y estado).
                        {
                            string direccionLocal = columns[1].PadRight(45);  // Dirección local, ¡con suficiente espacio para que se vea bien!
                            string direccionRemota = columns[2].PadRight(45);  // Dirección remota, igual de importante.
                            string estado = columns.Length > 3 ? columns[3].PadRight(20) : "";  // Estado de la conexión, si está disponible.

                            output.AppendLine(direccionLocal + direccionRemota + estado);  // Añadimos la información al StringBuilder. ¡Toda la data que necesitamos!
                        }
                    }
                }
                process.WaitForExit();  // Esperamos a que el proceso termine. No es como cuando tienes que esperar a que tu PC se apague, ¡esto pasa rápido!
            }

            return output.ToString();  // Devolvemos toda la información recogida como una cadena de texto.
        }
    }
}
