using System;  // Necesario para las funciones básicas de C# y la manipulación de objetos. Sin esto, no podemos ni decir "Hola Mundo".
using System.Diagnostics;  // Esto lo necesitamos para interactuar con el sistema operativo y obtener información de los procesos en ejecución. ¡Es como nuestro espía personal!
using System.Text;  // Usamos esto para construir cadenas de texto de manera eficiente. ¡Más rápido que una máquina de escribir!
using System.Windows.Forms;  // Importamos esto porque estamos creando una interfaz gráfica de usuario (GUI). ¡Nada de consola negra para nosotros!

namespace TaskManaggerFinalProject
{
    // Clase ProcessInfo: El área donde vigilamos los procesos que están trabajando en tu PC. ¡No hay secretos aquí!
    public static class ProcessInfo
    {
        // Método para crear un panel que muestra los procesos en ejecución. ¡Aquí es donde puedes ver cómo tu PC está trabajando!
        public static Panel CrearPanelProcesos()
        {
            // Crear el panel donde se mostrarán los procesos
            Panel panelProcesos = new Panel
            {
                Location = new System.Drawing.Point(10, 280),  // Lo ubicamos debajo de otros paneles, pero sin ser olvidado.
                Size = new System.Drawing.Size(600, 300),  // Tamaño suficiente para que quepan varios procesos. ¡Nada de estar apretados!
                AutoScroll = true,  // Si hay demasiados procesos, el panel tendrá barras de desplazamiento. ¡Nadie se queda afuera!
                BorderStyle = BorderStyle.FixedSingle  // Borde simple, pero firme como un monitor de trabajo.
            };

            // Crear un título general que diga "Procesos en Ejecución". Porque necesitamos saber quién está en acción.
            Label labelTitulo = new Label
            {
                Text = "Procesos en Ejecución",  // Título general del panel
                Location = new System.Drawing.Point(10, 10),  // Ubicación del título en el panel.
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),  // Hacemos el texto en negrita porque estos procesos están muy ocupados.
                AutoSize = true  // Aseguramos que el texto se ajuste al tamaño del label, sin sobrepasar los límites.
            };
            panelProcesos.Controls.Add(labelTitulo);  // Añadimos el título al panel.

            // Crear un encabezado con los nombres de las columnas. Aquí mostramos qué detalles veremos: nombre, PID y memoria.
            Label labelHeader = new Label
            {
                Text = FormatearEncabezado(),  // Formateamos los encabezados. El formato es clave.
                Location = new System.Drawing.Point(10, 40),  // Colocamos el encabezado justo debajo del título.
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),  // Usamos un tamaño adecuado para el encabezado.
                AutoSize = true,
                MaximumSize = new System.Drawing.Size(580, 0)  // Limitar el tamaño del encabezado para que se ajuste bien.
            };
            panelProcesos.Controls.Add(labelHeader);  // Añadimos el encabezado al panel.

            // Crear un label para mostrar los procesos en ejecución. Aquí es donde todos los detalles se muestran.
            Label labelProcesos = new Label
            {
                Text = ObtenerProcesosEnEjecucion(),  // Obtenemos la lista de procesos en ejecución.
                Location = new System.Drawing.Point(10, 70),  // Colocamos el label debajo del encabezado.
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 8),  // Ajustamos el tamaño de fuente para que todo quepa bien.
                MaximumSize = new System.Drawing.Size(580, 0)  // Limitar el tamaño para evitar que se desborde.
            };
            panelProcesos.Controls.Add(labelProcesos);  // Añadimos el label de procesos al panel.

            return panelProcesos;  // Devolvemos el panel completo, listo para ser mostrado.
        }

        // Método privado que genera el encabezado para los procesos. Aquí es donde definimos qué columnas mostrar.
        private static string FormatearEncabezado()
        {
            return "Nombre                      PID        Memoria";  // Definimos las columnas que veremos: Nombre del proceso, PID y memoria.
        }

        // Método privado que obtiene la lista de procesos en ejecución en el sistema. ¡Es como un paparazzi pero para procesos!
        private static string ObtenerProcesosEnEjecucion()
        {
            StringBuilder output = new StringBuilder();  // Usamos StringBuilder para construir nuestra salida de manera eficiente.

            // Ejecutar el comando "tasklist" y capturar la salida. ¡Es como un espía que recopila información sobre lo que está pasando!
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";  // Ejecutamos el cmd (sí, la vieja confiable).
                process.StartInfo.Arguments = "/c tasklist /fo table /nh";  // Ejecutamos el comando "tasklist" para obtener la lista de procesos sin encabezado.
                process.StartInfo.RedirectStandardOutput = true;  // Redirigimos la salida para poder leerla.
                process.StartInfo.UseShellExecute = false;  // No usamos la shell porque no necesitamos una ventana emergente.
                process.StartInfo.CreateNoWindow = true;  // Sin ventana para mantener las cosas limpias.
                process.Start();  // Iniciamos el proceso.

                string line;
                while ((line = process.StandardOutput.ReadLine()) != null)
                {
                    // Ajustamos el formato de cada línea para mejorar el espaciado. ¡No queremos que se vean todos desordenados!
                    string[] columns = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (columns.Length >= 3)
                    {
                        // Ajustamos el nombre del proceso para que ocupe un espacio fijo de 35 caracteres.
                        string nombreProceso = columns[0].PadRight(35);  // Nombre del proceso.

                        // Ajustamos el PID para que ocupe un espacio fijo de 25 caracteres.
                        string pid = columns[1].PadRight(25);  // PID del proceso.

                        // Ajustamos la memoria, si existe, para que ocupe un espacio fijo de 10 caracteres.
                        string memoria = (columns.Length >= 5) ? columns[columns.Length - 2] + " " + columns[columns.Length - 1] : "N/A";
                        memoria = memoria.PadRight(10);  // Espacio para mostrar la memoria.

                        // Construimos la línea final con el nombre, PID y memoria. ¡Todo bien alineado!
                        output.AppendLine(nombreProceso + pid + memoria);
                    }
                }
                process.WaitForExit();  // Esperamos a que el proceso termine antes de continuar.
            }

            return output.ToString();  // Devolvemos la lista de procesos en ejecución.
        }
    }
}
