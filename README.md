**Esta API sigue los principios de Clean Code y la arquitectura de diseño de software en capas, lo que facilita la lectura, el mantenimiento y la escalabilidad del código.**

**Capa de Dominio (Models)**: Esta capa contiene las clases de modelo Flight, Journey y Transport que representan la estructura de los datos con los que trabaja la aplicación.

**Capa de Servicios (Services)**: Esta capa contiene la lógica de negocio de la aplicación. En el servicio FlightService, se implementan los métodos para obtener todos los vuelos, obtener vuelos de ida, obtener vuelos de ida y vuelta y convertir monedas. Este servicio implementa la interfaz IFlightService, lo que permite un acoplamiento débil y facilita las pruebas unitarias.

**Capa de Presentación (Controllers)**: Esta capa maneja las solicitudes HTTP y devuelve las respuestas HTTP. El controlador FlightController utiliza la inyección de dependencias para acceder a los servicios de la aplicación. Los métodos del controlador corresponden a diferentes rutas de la API y devuelven datos en formato JSON.

**Capa de Infraestructura (Program.cs)**: Esta capa configura los servicios y la canalización de solicitudes HTTP. Se configura CORS para permitir solicitudes desde un origen específico, se registran los servicios para la inyección de dependencias y se configuran las rutas de la API.

El uso de Clean Code en esta API se evidencia en varias formas:

**Nombres significativos**: Los nombres de las clases, métodos y variables son descriptivos y reflejan su propósito.

**Funciones pequeñas**: Las funciones tienen una sola responsabilidad y son relativamente pequeñas, lo que facilita su comprensión y prueba.

**Uso de comentarios**: Los comentarios se utilizan para explicar el propósito y el funcionamiento de los bloques de código.

**Manejo de errores**: Se manejan los errores y se lanzan excepciones con mensajes claros.

**Formato consistente**: El código sigue un formato consistente, lo que facilita su lectura.

**Inyección de dependencias**: utilicé inyección de dependencias para proporcionar los servicios necesarios a las clases, lo que facilita las pruebas y reduce el acoplamiento.

**Uso de interfaces**: Las interfaces las utilicé para definir contratos para los servicios, esto permite un acoplamiento débil y facilita las pruebas unitarias.

####

**La aplicación creada en Angular, es una interfaz grafica sencilla que permite buscar y mostrar todos los vuelos.**
Creé tres **interfaces** que representan los 3 modelos utilizados en la aplicación, esto para optimizar el tipado, excluyendo el manejo de el tipo 'any'
así mismo cree, una **variable de entorno** donde se agregó la URL del backend, que posteriormente se llamará en el servicio, donde se interactua con la API de vuelos.
En el Servicio se manejan los métodos que deben tener los mismos nombres del backend, estos permitirán obtener el tipo de vuelos según los parámetros

Se creo un componente llamado **fligh-list** este componente se llama en el app component por medio del router-outlet usando la importación de RouterModule en el app.module.ts así que el componente principal es `FlightListComponent`, que muestra la lista de vuelos. Utiliza el servicio `FlightService` para obtener los datos de los vuelos y luego los muestra en la vista.

en el archivo .ts del componente principal `fligh-list.component.ts` se manejan los siguientes métodos:

En **ngOnInit()**, se llama al método getAllFlights() para obtener todos los vuelos cuando se inicializa el componente.
**getAllFlights()** obtiene todos los vuelos y extrae los orígenes y destinos únicos de los vuelos.
**displayAllFlights()** se utiliza para mostrar todos los vuelos.
**getFlights()** obtiene los vuelos basados en los parámetros seleccionados por el usuario.
**displaySearchedFlights()** se utiliza para mostrar los vuelos que coinciden con los criterios de búsqueda del usuario.

en el archivo `fligh-list.component.html` se realizó el esqueleto del formulario, en el cual el usuario elegirá los parametros de busqueda para los vuelos, este incluye botones que muestran vuelos especificos o todos los vuelos, valores que posteriormente se mostrarán en la tabla al presionar los respectivos botones.
en el archivo `fligh-list.component.scss` se están manejando media queries para que el diseño funcione de manera responsiva y se adapte a distintos tipos de dispositivos, los estilos se estan anidando para mantener un codigo limpio y organizado.

**Tiempo de realización del proyecto, inicié el Lunes después del medio día, hasta las 00 horas del miércoles**
