# CalculatorService.Server
 The main component of the application, and the one actually implementing the 'calculator service’ HTTP/REST interface &amp; business logic

Aplicación realizada con WebApi2, C# y Visual Studio 2015

Esta aplicación contiene un servicio web y distintos métodos y acciones, que permiten al usuario realizar operaciones aritméticas de suma, resta, multiplicar, dividir y raiz cuadrada. además dar la opción al usuario de consultar operaciones por un determinado ID. Dicho ID se puede pasar o no en las cabeceras de las llamadas a cada acción.

las acciones son las siguientes:

add - realiza la suma de varios numeros y devuelve el resultado. 
      Este método espera un array de 'int' y devuelve el resultado en un JSON
sub - resta entre dos numeros y devuelve el resultado. 
      Este método espera dos 'int'  y devuelve el resultado en un JSON
mult - realiza la multiplicación de varios números y devuelve el resultado. 
      Este método espera un array de 'int'  y devuelve el resultado en un JSON
div - realiza la división entre dos números y devuelve el resultado y su resto. 
      Este método espera dos 'int' dividendo y divisor  y devuelve el resultado en un JSON    
sqrt - realiza la raíz cuadrada de un determinado número. 
      Este método espera un 'int' sobre el que calcula la raiz cuadrada  y devuelve el resultado en un JSON
query - devuelve una lista de operaciones registradas con un mismo Id. 
      Este método espera un 'int'  y devuelve el resultado en un JSON con una lista de operaciones registradas
      
REFERENCIAS EXTERNAS:

NLOG y NLOGWEB : https://www.nuget.org/packages/NLog
  Estas herramientas permiten crear un log diferenciando el tipo de entrada (Error, Trace e Info).
MEMORYCACHE: https://www.nuget.org/packages/MemoryCache/
  Esta herramienta permite guardar en el cache del servidor contenidos, en este caso se guardaban las operaciones aritmeticas si se recibia en la cabecera de la llamada el parámetro 'X-Evi-Tracking-Id'
  
  
