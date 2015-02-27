Propuesta Proyecto Agente Inteligente.
 
LUIS FELIPE FLECHAS MORATO
80212135
 
JUEGO UNO
 
 
 
El proyecto que se desarrollara será el juego UNO, el cual tendrá varias modificaciones con referencia al reglamento normal, las cuales serán:
 
·         El juego solo tendrá 24 cartas las cuales estarán compuestas con los números del 1 al 5 de los colores amarillo y azul (2 de cada una), un +2 amarillo, un +2 azul, un salta amarillo y un salta azul.
·         Se repartirán 4 cartas por jugador y una carta en la mesa, el jugador deberá poner en la mesa una carta que coincida con el número o el color de la carta que se encuentra en la mesa, en caso de no tener una carta que coincida deberá tomar una carta de la baraja y si es una carta que puede votar a la mesa lo hará o en caso contrario pasará el turno.
·         Cuando un jugador se quede sin cartas se tomaran las cartas del oponente y se sumaran con los siguientes valores: los números tendrán su valor nominal y las cartas de penalidad (+2 o salta) tendrán un valor de 10. Se repartirán nuevamente las cartas y el jugador que primero llegue a un puntaje de 80 ganará e juego.
 
 
Definición del problema
 
Estado inicial:
Cuando tengo las cartas que se reparten para comenzar a hacer la búsqueda.
 
Operadores :
Votar una carta a la mesa o coger carta de la baraja.
 
Función sucesor:
Evaluar si tengo carta con el color que corresponde  y en caso que no evaluar si tengo un numero.
 
Prueba de Meta.
Cuando finalice una partida, después de sumar los valores de las cartas del oponente que perdió,  se evaluará el marcador acumulado validando si llego a los 80 puntos.
 
Costo de ruta:
Tienen mayor costo para mi votar una carta con menor valor ya que en caso de perder la partida le sumaran más puntos al contrincante.
 
 
 
 
 
 
 
Definición del Agente:
 
El propósito del Agente           	es llegar a un marcador de 80 puntos para ganar el juego.
 
El entorno son las cartas de juego, el cual es parcialmente observable, estratégico, secuencial y discreto.
Es un multiagente competitivo - se dejara para solo dos jugadores.
 
Matriz REAS
 
Medidas de rendimiento
Entorno
Actuadores
Sensores

 
Cartas de juego Parcialmente observable
Componente del programa para poder mover una carta desde la mano del jugador hasta la mesa o desde el maso hasta la mano del jugador.
Percepción del jugador para determinar cuando tiene turno y ver la última carta puesta en la mesa, para poder escoger que carta puede bajar a la mesa.
Cuando un jugador queda sin cartas se hace una sumatoria de los puntos que tiene el contrincante (para las cartas numericas es el valor nominal y para las demas el valor es 20). El jugador que primero llegue a 200 puntos gana.
Estrategico, Secuencial, Discreto.


Multiagente competitivo - se dejara para solo dos jugadores.
 
 
Propuesta tecnológica:
El proyecto se desarrollara en la plataforma Unity con javascript para aplicación de escritorio.
 
 
 
Cronograma
 
FECHA
ACTIVIDAD
17/02/2014
Entorno, matriz de mapeo
20/02/2014
Avance agente reflejo simple
27/02/2014
Agente Reflejo simple
