# CalculatorService.Server
_The main component of the application, and the one actually implementing the 'calculator service’ HTTP/REST interface &amp; business logic_

Aplicación realizada con WebApi2, C# y Visual Studio 2015

Esta solución contiene un servicio web y distintos métodos y acciones, que permiten al usuario realizar operaciones aritméticas de suma, resta, multiplicar, dividir y raiz cuadrada. Además ofrece al usuario la opción de consultar operaciones a partir de un determinado Id de operación. Dicho Id es opcional, y se debe establecer en la cabecera de la llamada al servicio.

Las operaciones son las siguientes:

* Add - realiza la suma de varios numeros y devuelve el resultado. 
      Este método espera un array de 'int' y devuelve el resultado en un JSON
* Sub - resta entre dos numeros y devuelve el resultado. 
      Este método espera dos 'int'  y devuelve el resultado en un JSON
* Mult - realiza la multiplicación de varios números y devuelve el resultado. 
      Este método espera un array de 'int'  y devuelve el resultado en un JSON
* Div - realiza la división entre dos números y devuelve el resultado y su resto. 
      Este método espera dos 'int' dividendo y divisor  y devuelve el resultado en un JSON    
* Sqrt - realiza la raíz cuadrada de un determinado número. 
      Este método espera un 'int' sobre el que calcula la raiz cuadrada  y devuelve el resultado en un JSON
* Query - devuelve una lista de operaciones registradas con un mismo Id. 
      Este método espera un 'int'  y devuelve el resultado en un JSON con una lista de operaciones registradas
      
**REFERENCIAS EXTERNAS**

* [NLOG y NLOGWEB](https://www.nuget.org/packages/NLog):
  Librerías que permiten crear un fichero de log, diferenciando el tipo de entrada (Error, Trace, Warm, Fatal o Info).
* [MEMORYCACHE](https://www.nuget.org/packages/MemoryCache):
  Librería que permite almacenar en el cache del servidor información. Empleada para almacenar las operaciones aritméticas si se reciben en la cabecera de la llamada el parámetro _X-Evi-Tracking-Id_.
  
  
