# U_Examen2_ClaudioGonzalez

 En este README, Se explicaran algunas partes de codigo que ejecuta el juego para una mejor comprension:
 PistasController:
 Se definen las variables para su utilizacion en el codigo y en inspector
 Se inicializa la variable playerInventory en Start() para conseguir el componente Inventario (script)
 Se crea el OnTriggerEnter() para escribir los case que daran logar a la interaccion del objeto y su utilizacion en el juego, asi como la destruccion del mismo en el escenario
 Se crean clases para la confirmacion del objeto

 CamaraController:
 primero se definene las variables de dos camaras utlizando el cinemachineVirtualCamara
 Luego se definen las clases de la camara 1 y la camara dos, definiendo sus prioridades para sus cambios de angulos

 DoorController:
 Al definir las variables en este scripts, se llama a los scripts Pistas y Camara controller, colocandoles un nombre que las defina en el codigo para su utlizacion
 Los GameObject de  Animacion y colision tambien son definidos con GO al final de su nombre dado
 Lo anterior puesto que tambien definimos un Collider y Un Animator con un nombre similar
 En Start() juntamos las varaibles de los objetos con su respectibo Componente con GETCOMPONENT, Colocando su elemento a utilizar  en <>(Collider y animator)
 Creamos la clase TriggerEnter para definir lo que pasara al momento de colicionar con las pistas, en este caso, al colisionar con la puerta al final, iniciara un cambio de camara, definida en el CamaraController,
Tambien se define un OnTriggerExit para cuando se sale del collider, cambiando a la camra inicial

LinternController:
Se definien las variables a utilizar, el scritp de las pistas y el componente de luz, asi como una varaible booleanna para su activacion
En el Update() se crea un IF, en cual se define que si en el script de pistas se encuenta la funcion solicitada entonces, si (Otro IF) se presiona F la linterna pasara a activarse si no esta activa (false a true) y de reversa si se vuelve a apretar

DangerZoneController:
En este archivo, definimos las variables del gameobject y de un entero (int) que corresponde a la vida a decreser(quitar) en 10, ademas de un Ienumerator que actuara para la corrutina de daño
En el start() inicializamos la corrutina como la clase dangerzonefire()
creamos un ontriggerenter para activar la corrutina si es que el objeto con el tag "player", colisiona con el collider
Luego creamos el elemento de corrutina IEnumerator dangerzonefire(), y dentro de este mientras (while) la salud que se encuentra dentro de la instancia del Gamemanage sea mayor que 0, se empezara un bucle en cual el gameobject dangerzoneUi, se activara, decresera la salud de acuerdo a lo colocado en el Gamemanage, se imprimira un mensaje de aviso, se esperara un 1 segundo, se desactivara el UI y se volvera a activar tras 1 segundo en un bucle.
cuando la salud llegue a ser menor o iguala 0, se cargara la escena de GameOver

HealthBarController:
Se definen las variables, donde los elementos de Scrollbar, TextMeshProUGUI y Gamemanage, son nombrados para su utilizacion en el codigo de barra de salud
Se inicializa en el start la variable de GameManage, donde si la varaible es nula impirma un mensaje de no encontrado
en el update(), se coloca el nombre de la funcion que actualizara la barra de salud, de esta manera, cada vez que se le inflija daño al personaje, la pantalla actualizara de acuerdo a lo programado en la clase
En la clase UpdateHealthBar() colocamos una varible de valor objetivo, la cual es la salud del personaje, descrita en el Gamemanage, transformada en flotante y dividida en 100f,
se inicia una corrutina de animacion para la barra de salud con la clase AnimatedHealthBar donde se utilizara la variable del valor objetivo,
se escribe un IF, donde si el texto de salud no es nulo, entonces el texto pasara a ser los numeros de la salud que se transformaran en String
En la corrutina Ienumerator mientras el calculo del tamaño de la barra de vida restado con el valor objetivo sea mayor a 0.01f, el tamaño de la barra de vida se ira actualizando a una velocidad definida en las variables, hasta alcanzar el resultado de la resta y se actualziara el tamaño como la nueva varaible objetico y se actualizara el color
en UpdateHandleColor(), se definira para cambiar el color de la barra de vida de acuerdo a la vida actual del jugador, mientras sea mayor a 0.5f (50%) sera verde, luego pasara a amarillo y luego a rojo a medida que perida salud.

EnemyController:
Se definen las variables a utilizar, NavMeshAgent para el recorrido del enemigo, los waypoints en un array para los puntos donde debe ir el enemigo, una cuenta de dichos waypoints, una distancia para el cambio de los points, configuraciones para el daño,detenccion,rango ataque y cooldown, asi como una varible para el ultimo ataque, una variable enum para el estado del enemigo y una variable para el estado actual del enemigo (patrullaje en este caso) y una referncia al jugador
en Start():
se une la varaible agent con el componente NavmeshAgent para obtener este mismo
se crea una variable gameobject player la cual busca el objeto con el tag player
si no es nulo, se obtienen las coordenadas del jugador y si lo es se imprime mensaje en consola
se comienza con el patrullaje
En el update se escribe en switch los estados del enemigo, el patrol, el chase y el attack, utilizando de refencia las posiciones del enemigo y del jugador y dependiendo de su distancia se activa cada una.
en la clase MOVETONEXTWAYPONT es para actualizar el indice de waypoint actual para moverse entre ellos
tambien se presenta una parte del codigo que funciona como giro para mirar al jugador esta parte posee Quaternion, que funciona para representar las rotaciones en 3d, en este caso para mirar a direccion del vector y lookrotation para mirar al jugador

Gamemanage:
este archivo no solo sirve para evitar la repeticion de instancias en el juego, evitando un sobre consumo, ademas tambien, sirve para guardar clases que se podran utilizar en todo el juego y no acceder desde diferentes elementos (ej: la vida esta escrita en este script, se evita repetir constantemente en otros scripts)

MenuMange:
este script tiene como funcion guardar las clases que se ocuparan de los diferentes menus, como el game over y el menu principal.
