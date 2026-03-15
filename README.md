# 📦 Mi Sistema de Inventario en C#

## 🌟 ¿Qué hace este programa?

El sistema es muy fácil de usar y está dividido en tres pestañas:

* **➕ Agregar Producto:** Puedes registrar un artículo nuevo escribiendo su nombre y la cantidad que tienes.
* **📋 Ver Inventario:** Muestra una lista actualizada con todos los productos que has guardado.
* **⚙️ Gestionar:** Te permite seleccionar un producto de la lista para cambiarle el nombre, actualizar su cantidad o borrarlo si ya no lo necesitas.

*Nota: Actualmente el sistema funciona como un simulador. Los datos se guardan en la memoria temporal, por lo que al cerrar el programa la lista se limpia sola (ideal para hacer pruebas rápidas).*

## 🛡️ A prueba de errores
El programa está diseñado para no fallar si el usuario se equivoca. Por ejemplo:
* Si intentas guardar un producto sin escribir su nombre, te avisa.
* Si por error escribes letras (como la palabra "diez") en lugar de números en la cantidad, te muestra un mensaje para que lo corrijas.

## 🛠️ ¿Qué usé para crearlo?

* **Lenguaje:** C# (C-Sharp)
* **Diseño de las ventanas:** WPF y XAML (las herramientas de Microsoft para dibujar pantallas)
* **Editor de código:** Visual Studio

## 🚀 ¿Cómo probarlo en tu computadora?

1. Descarga los archivos de este repositorio (puedes usar el botón verde de "Code" y darle a "Download ZIP").
2. Descomprime la carpeta y haz doble clic en el archivo que termina en `.sln`. Esto abrirá el proyecto en **Visual Studio**.
3. Una vez abierto, presiona la tecla **F5** (o el botón verde de "Play" en la parte superior).
4. ¡Listo! La ventana del programa se abrirá y podrás empezar a usarlo.
