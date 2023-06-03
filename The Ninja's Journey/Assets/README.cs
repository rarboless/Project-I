/*
Menú:
Hemos creado una escena del menú que contiene diferentes botones,
dentro de la misma escena está en main menu, settings y levels,
se activan o desactivan dependiendo del botón pulsado.
También dentro de la partida hay la opción de pausa,
se puede activar tanto con la tecla ESC como por el botón de la esquina superior derecha.
En este se puede regular el volumen tanto de la música como de los efectos de sonido,
que se guarda entre escenas, el botón de continuar y finalmente volver al menú principal 
(se reinicia la vida, monedas y armas).

Audio:
Hemos añadido efectos de sonido a los disparos, al coger las armas y monedas,
al recibir daño tanto al jugador como a los enemigos, al curarse y cuándo se efectúa clics en los botones del menú.
La música cambia dependiendo de la escena en la que estemos y tiene un fade de 5 segundos.
Hay un mixer en Prefabs desde el cual los sliders del menú de pausa controlan el sonido.

Efectos:
Hemos creado efectos de partículas de lluvia (la escena tiene un filtro que oscurece la pantalla) y el contacto con el agua en la escena Exterior, en esta misma escena
si se mantiene pulsado la tecla k la particula de lluvia se detiene y aparece la de ojas cayendo. Al dejar de pulsar la tecla la de las ojas se detiene y comienza de nevo
la lluvia.
También a los dos tipos de enemigos y a las armas, uno para cada tipo de arma.
Se encuentran en la carpeta Particles.

*/