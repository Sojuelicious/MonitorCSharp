# Proyecto: Monitoreo de Recursos del Sistema en C#

Este proyecto en C# permite monitorear y visualizar en tiempo real información sobre los recursos del sistema, como los procesos en ejecución, las conexiones de red activas, el uso de la CPU y la memoria disponible, todo dentro de una interfaz gráfica desarrollada con **Windows Forms (WinForms)**.

El proyecto fue creado utilizando **Visual Studio Code**, un editor de código fuente ligero y altamente personalizable. Aunque **Visual Studio** es una opción popular para proyectos C#, este proyecto muestra cómo es posible desarrollar aplicaciones de escritorio con **C# y WinForms** en **Visual Studio Code**. 

### ¿Por qué Visual Studio Code y el SDK de .NET?

1. **Visual Studio Code** es un editor de código que, aunque no está especializado en proyectos C# como **Visual Studio**, ofrece una experiencia de desarrollo eficiente y flexible. Con la instalación de extensiones adecuadas, Visual Studio Code permite trabajar con C# y otros lenguajes de programación sin perder funcionalidad.

2. **SDK de .NET** es el conjunto de herramientas que permite compilar y ejecutar aplicaciones en C#. Para este proyecto, el SDK de .NET fue utilizado para compilar y ejecutar el código C# desde la terminal, facilitando el desarrollo y la gestión del proyecto.

## Funcionalidades del Proyecto

Este proyecto incluye los siguientes módulos para monitorear diferentes aspectos del sistema:

- **Monitoreo de Procesos**: Muestra una lista de los procesos en ejecución, incluyendo su nombre, PID (ID del proceso) y el uso de memoria.
- **Conexiones de Red**: Muestra las conexiones activas de red, tanto entrantes como salientes.
- **Monitoreo de Recursos**: Muestra en tiempo real el uso de CPU y la cantidad de memoria disponible en el sistema.
- **Información de Software Abierto**: Lista las aplicaciones abiertas con ventanas visibles.
- **Versión de Windows**: Muestra la versión del sistema operativo Windows.

## Estructura de Archivos del Proyecto

El proyecto está organizado de la siguiente manera

- **Form1.cs**: Archivo principal que contiene la lógica para crear las ventanas y mostrar la interfaz, gestionando eventos y actualizando la información del sistema.
- **Carpeta "Tasks"** : En esta carpeta estan los siguietnes archivos
  - **ProcessInfo.cs**: Contiene la lógica para obtener y mostrar los procesos en ejecución, incluyendo el PID y el uso de memoria.
  - **NetworkConnections.cs**: Obtiene y muestra las conexiones de red activas, las conexiones entrantes y las conexiones salientes
  - **PerformanceMonitor.cs**: Monitorea en tiempo real el uso de CPU y la memoria del sistema
  - **SoftwareInfo.cs**: Muestra las aplicaciones que tenemos abiertas en ese momento especifico, al ejecutar el programa
  - **WindowsInfo.cs**: Muestra la versión del sistema operativo Windows.

## Hazlo Tú

Para empezar a trabajar con este proyecto, sigue estos pasos:
### 1. Crea la Carpeta del Proyecto

1. Crea una carpeta con el nombre de tu proyecto.
2. Haz **click derecho** dentro de la carpeta.
3. Selecciona la opción **"Abrir en Terminal"**.
   
   Esto abrirá la consola, que es la terminal que usarás para las siguientes instrucciones.

   >Si no tienes la opcion **"Abrir en Terminal"** entonces abre una terminal cualquiera y navega hasta la carpeta que acabas de crear para tu proyecto


### 2. Clona el Repositorio

Clona el repositorio a tu máquina local.

```bash
https://github.com/Sojuelicious/MonitorCSharp.git
```

### 3. Abre el Proyecto en Visual Studio Code

Una vez clonado el repositorio, navega a la carpeta del proyecto y ábrelo en Visual Studio Code. Usa los siguientes comandos en la terminal:

```bash
cd MonitorCSharp
code .
```

### 4. Instala las Dependencias

Si aún no tienes el SDK de .NET instalado, asegúrate de instalarlo desde el [sitio oficial de .NET](https://dotnet.microsoft.com/download).

Una vez que tengas el SDK de .NET instalado, abre la terminal en Visual Studio Code y ejecuta el siguiente comando para instalar las dependencias necesarias para el proyecto:

```bash
dotnet restore
```

### 5. Compila y Ejecuta la Aplicación

Para compilar y ejecutar la aplicación, utiliza los siguientes comandos en la terminal de Visual Studio Code:

1. **Compilar el proyecto**:
    ```bash
    dotnet build
    ```

2. **Ejecutar la aplicación**:
    ```bash
    dotnet run
    ```

El primer comando compilará el proyecto, asegurándose de que todo el código esté listo para ser ejecutado. El segundo comando iniciará la aplicación, y podrás ver cómo se abre la interfaz de usuario con las diferentes funcionalidades implementadas.

