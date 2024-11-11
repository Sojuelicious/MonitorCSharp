using System;  // Necesario para las funciones básicas de C# y la manipulación de objetos. Sin esto, estaríamos perdidos.
using System.Diagnostics;  // Traemos esto para interactuar con el sistema y obtener datos de rendimiento en tiempo real, como el uso de CPU y memoria. ¡Todo un espía de tu sistema!
using System.Windows.Forms;  // Importamos esto porque estamos trabajando con interfaces gráficas de usuario (GUI). ¡Lo que ves en pantalla es gracias a esto!

namespace TaskManaggerFinalProject
{
    // Clase PerformanceMonitor, ¡donde todo se pone serio! Aquí es donde vigilamos el estado de tu PC con el ojo de un halcón.
    public static class PerformanceMonitor
    {
        // Método que crea el panel de monitoreo de recursos, como un tablero de control para observar el rendimiento de tu sistema.
        public static Panel CrearPanelMonitoreo()
        {
            // Crear un panel para mostrar los recursos monitoreados
            Panel panelMonitoreo = new Panel
            {
                Location = new System.Drawing.Point(620, 280),  // Colocamos el panel al lado de los procesos. ¡Nunca tan cerca, pero siempre vigilante!
                Size = new System.Drawing.Size(600, 300),  // Tamaño del panel. No tan grande como tu lista de tareas pendientes, pero suficientemente grande para mostrar todo.
                AutoScroll = true,  // Si los datos se desbordan, que el panel tenga barra de desplazamiento, como cuando un post se hace viral.
                BorderStyle = BorderStyle.FixedSingle  // Borde sencillo pero firme, para que se note que este panel tiene autoridad.
            };

            // Crear un título para el panel de monitoreo
            Label labelTitulo = new Label
            {
                Text = "Monitoreo de Recursos",  // Título general, porque todo tablero de control necesita su nombre.
                Location = new System.Drawing.Point(10, 10),  // Ubicamos el título en la parte superior del panel.
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),  // Le damos un toque de seriedad al título, nada de fuente Comic Sans.
                AutoSize = true  // Dejamos que el tamaño del texto se ajuste automáticamente al contenido.
            };
            panelMonitoreo.Controls.Add(labelTitulo);  // Añadimos el título al panel. ¡Primera parte de la misión cumplida!

            // Crear un encabezado para la CPU
            Label labelCPUHeader = new Label
            {
                Text = "CPU(%)",  // Título para la CPU, porque necesitamos saber cuánto esfuerzo está poniendo tu procesador.
                Location = new System.Drawing.Point(10, 40),  // Ubicación de la etiqueta en el panel.
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),  // Fuente con estilo. Todo lo que monitoreamos es importante.
                AutoSize = true  // Ajustar el tamaño al texto.
            };
            panelMonitoreo.Controls.Add(labelCPUHeader);  // Añadimos el encabezado de CPU al panel.

            // Crear un Label para mostrar el uso de CPU
            Label labelCPU = new Label
            {
                Location = new System.Drawing.Point(10, 70),  // Ubicación del Label de uso de CPU.
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 30, System.Drawing.FontStyle.Bold)  // Texto grande y en negrita. Porque el uso de la CPU tiene que destacarse.
            };
            panelMonitoreo.Controls.Add(labelCPU);  // Añadimos el label que mostrará el uso de CPU al panel.

            // Crear un encabezado para la Memoria
            Label labelMemoriaHeader = new Label
            {
                Text = "Memoria(MB)",  // Título para la memoria. ¡Porque necesitamos saber cuánta memoria queda para más cosas importantes como juegos!
                Location = new System.Drawing.Point(10, 140),  // Colocamos el encabezado un poco más abajo, para que no se mezcle con el de CPU.
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),  // Un toque serio para la memoria.
                AutoSize = true  // Ajuste automático al tamaño.
            };
            panelMonitoreo.Controls.Add(labelMemoriaHeader);  // Añadimos el encabezado de memoria al panel.

            // Crear un Label para mostrar la memoria disponible
            Label labelMemoria = new Label
            {
                Location = new System.Drawing.Point(20, 160),  // Colocamos el Label de memoria justo debajo del encabezado de memoria.
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 30, System.Drawing.FontStyle.Bold)  // Texto grande y en negrita. Porque necesitamos ver si tu PC se está quedando sin memoria.
            };
            panelMonitoreo.Controls.Add(labelMemoria);  // Añadimos el label de memoria al panel.

            // Llamar al método para actualizar el monitoreo cada segundo. ¡Como un reloj suizo, pero para tu PC!
            ActualizarMonitoreo(labelCPU, labelMemoria);

            return panelMonitoreo;  // Devolvemos el panel completo, listo para mostrar el monitoreo de recursos.
        }

        // Método privado que actualiza el monitoreo de recursos, porque un "monitoreo estático" es tan útil como un reloj roto.
        private static void ActualizarMonitoreo(Label labelCPU, Label labelMemoria)
        {
            // Usar PerformanceCounter para obtener datos en tiempo real. Este es nuestro "espía" para saber qué pasa dentro del sistema.
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");  // Contador para CPU. ¡Queremos saber si el procesador está haciendo ejercicio!
            PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available MBytes");  // Contador para memoria disponible. ¡Porque la memoria libre es como espacio en un tren lleno!

            // Crear un Timer para actualizar los valores cada segundo. ¡Cero excusas, cada segundo cuenta!
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;  // Actualizar cada 1 segundo. ¡A la velocidad de la luz!
            timer.Tick += (sender, e) =>
            {
                // Obtener el uso de CPU en tiempo real. ¡Es hora de saber si tu PC está trabajando demasiado!
                float cpuUsage = cpuCounter.NextValue();  // Obtener el valor actual del uso de CPU.
                // Obtener la memoria disponible. ¡Necesitamos saber si está quedando espacio para más memes!
                float availableMemory = memCounter.NextValue();  // Obtener la cantidad de memoria disponible en MB.

                // Actualizar el texto de los Labels con los nuevos valores obtenidos. ¡Ahora sí, que el monitoreo esté siempre actualizado!
                labelCPU.Text = "CPU " + cpuUsage.ToString("0.00") + "%";  // Mostrar el uso de la CPU con 2 decimales.
                labelMemoria.Text = "Memoria: " + availableMemory.ToString("0.00") + " MB";  // Mostrar la memoria disponible en MB, con 2 decimales.
            };

            timer.Start();  // Empezamos el timer. ¡Ahora todo se actualiza a la velocidad del rayo!
        }
    }
}
