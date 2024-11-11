using System;  // Esto importa el espacio de nombres System, que es donde se encuentran muchas clases básicas del lenguaje, como 'Console' y 'String'. Es lo que permite que el sistema respire.
using System.Diagnostics;  // Aquí es donde entra 'Process' para ejecutar cosas como DxDiag... ¡porque a veces necesitamos saber qué está pasando bajo el capó!
using System.IO;  // Si alguna vez quieres leer o escribir en archivos (¡como este genial archivo de dxdiag que vamos a crear!), necesitas 'System.IO'. Básicamente, le dices a tu programa dónde guardar las cartas.
using System.Windows.Forms;  // Esto es necesario si estás creando una interfaz gráfica de usuario. Si quieres que aparezcan ventanas, botones y demás, esta es la librería que se encarga de eso.

namespace TaskManaggerFinalProject
{
    // Esta es la clase 'HardwareInfo', donde recopilamos información sobre el hardware de la máquina. ¡Es como un detective pero para piezas de computadora!
    public static class HardwareInfo
    {
        // Aquí es donde vamos a guardar el archivo con la salida de DxDiag en nuestro proyecto. Vamos a ser honestos, necesitamos saber qué está haciendo nuestro PC.
        private static string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "dxdiag_output.txt");

        // Método principal para mostrar la información del hardware en un panel.
        // La tarea de este método es crear un panel en el formulario donde vamos a mostrar todos los detalles de nuestro hardware. ¡El panel es como el escenario, el hardware es el show!
        public static Panel MostrarHardware()
        {
            // Crear un panel para la sección de hardware. Este panel será como el contenedor donde vamos a poner toda la magia.
            Panel panelHardware = new Panel
            {
                Location = new System.Drawing.Point(10, 70),  // La ubicación del panel en el formulario. ¡Queremos que aparezca en la pantalla, no fuera de ella!
                Size = new System.Drawing.Size(600, 200),    // El tamaño del panel. No queremos que sea demasiado pequeño ni tan grande como una pantalla de cine.
                AutoScroll = true,  // Permite que se pueda desplazar si la información es demasiado larga. ¡Porque todos tenemos mucho que decir!
                BorderStyle = BorderStyle.FixedSingle  // Establece un borde simple alrededor del panel. ¡Para que se vea bonito!
            };

            // Crear el encabezado para la sección de hardware, ¡porque todo necesita un título épico!
            Label labelHardwareHeader = new Label
            {
                Text = "Hardware Detectado:",  // El texto que aparece en el encabezado. ¡Nada como un título claro y directo!
                Location = new System.Drawing.Point(10, 10),  // Ubicación del encabezado en el panel.
                AutoSize = true,  // El encabezado se ajusta automáticamente al texto. ¡Evita que se salga de control!
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)  // Un font de Arial, porque todos sabemos que Arial es el rey de la legibilidad.
            };
            panelHardware.Controls.Add(labelHardwareHeader);  // Añadir el encabezado al panel.

            // Obtener la información del hardware llamando a nuestro método que hace el trabajo sucio.
            string hardwareInfo = GetEssentialHardwareInfo();

            // Crear una etiqueta para mostrar la información del hardware. ¡Esto es lo que vamos a ver en el panel!
            Label labelHardwareInfo = new Label
            {
                Text = hardwareInfo,  // La información de hardware se coloca en esta etiqueta. 
                Location = new System.Drawing.Point(10, 40),  // Ubicación dentro del panel.
                AutoSize = true  // El tamaño de la etiqueta se ajusta al contenido. Nada de espacio desperdiciado.
            };
            panelHardware.Controls.Add(labelHardwareInfo);  // Añadir la etiqueta con la información al panel.

            return panelHardware;  // Devolvemos el panel con toda la información. ¡Está listo para brillar!
        }

        // Método que obtiene la información esencial del hardware.
        // ¿Qué tan esencial es? ¡Lo suficientemente esencial como para que tu PC no se sienta olvidado!
        public static string GetEssentialHardwareInfo()
        {
            // Verificar si el archivo ya existe. Si no, lo generamos. ¡La vida no es tan fácil como hacer clic en un botón!
            if (!File.Exists(outputFilePath))
            {
                // Generar el archivo con la salida de DxDiag. ¡Es como una cita con la verdad para el sistema!
                GenerarDxDiagFile();
            }

            // Leer el archivo generado con la salida de DxDiag. ¡La lectura es el segundo paso de nuestro plan maestro!
            string dxDiagOutput = File.ReadAllText(outputFilePath);

            // Aquí vamos a guardar la información que realmente necesitamos, y no, no es todo lo que DxDiag tiene para ofrecer, solo lo esencial.
            string essentialInfo = "";

            // Buscar la información del sistema operativo, procesador, memoria, tarjeta gráfica, etc.
            essentialInfo += GetMatchedLine(dxDiagOutput, @"Operating System\s*:\s*(.*)") + Environment.NewLine;
            essentialInfo += GetMatchedLine(dxDiagOutput, @"Processor\s*:\s*(.*)") + Environment.NewLine;
            essentialInfo += GetMatchedLine(dxDiagOutput, @"Memory\s*:\s*(.*)") + Environment.NewLine;
            essentialInfo += GetMatchedLine(dxDiagOutput, @"Card name\s*:\s*(.*)") + Environment.NewLine;
            essentialInfo += GetMatchedLine(dxDiagOutput, @"Disk & DVD/CD-ROM Drives\s*:\s*(.*)") + Environment.NewLine;

            return essentialInfo;  // Devolvemos toda la información esencial que hemos recogido. ¡El hardware ya no tiene secretos para nosotros!
        }

        // Método privado para generar el archivo de salida de DxDiag, que es como una consulta profunda al sistema.
        private static void GenerarDxDiagFile()
        {
            // Crear un nuevo proceso para ejecutar DxDiag. Es como pedirle a tu computadora que se abra y te muestre sus secretos.
            Process process = new Process();
            process.StartInfo.FileName = "dxdiag";  // ¡Llamamos a la herramienta DxDiag para que nos cuente todo sobre el hardware!
            process.StartInfo.Arguments = $"/t \"{outputFilePath}\"";  // Decimos a DxDiag que guarde la salida en un archivo.
            process.StartInfo.UseShellExecute = false;  // No queremos abrir una ventana de consola innecesaria. ¡A nadie le gusta eso!
            process.StartInfo.CreateNoWindow = true;  // Tampoco necesitamos ver la ventana de DxDiag. Queremos que sea discreto.
            process.Start();  // Iniciamos el proceso.
            process.WaitForExit();  // Esperamos a que termine el proceso de DxDiag. ¡Paciencia, joven padawan!
        }

        // Método para obtener una línea específica utilizando expresiones regulares.
        private static string GetMatchedLine(string input, string pattern)
        {
            // Usamos una expresión regular para buscar una línea que coincida con el patrón dado. ¡Es como buscar una aguja en un pajar, pero más elegante!
            var match = System.Text.RegularExpressions.Regex.Match(input, pattern);
            if (match.Success)
            {
                // Si encontramos una coincidencia, devolvemos el valor correspondiente. ¡Lo conseguimos!
                return match.Groups[1].Value.Trim();
            }
            return "Información no encontrada";  // Si no encontramos nada, devolvemos un mensaje triste.
        }
    }
}
