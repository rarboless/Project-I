/*
    - Quan el personatge perd vida, disminueix la seva velocitat de moviment.
    - Hi han monedes en el mapa per recol�lectar, a la entrega final �s guardran entre escenes.
    - A m�s de les monedes com a pick-ups, tamb� tenim picks ups curatius, fa que puguis recuperar una vida o tota depenent de la mida del cor.
    - Els canvis de d'escena funcionen com a checkpoints, restauren la vida i quan mors apareixes en l'�ltim canvi de d'escena que has fet.
    - Tamb� hi ha pickups de les armes per poder aconseguir aquesta (nom�s dos d�implementades, de moment: arc i shuriken. Cadascuna te velocitat de dispar i mal diferent)
    - Hi ha dos tipus d'enemics que hem implemenent de moment:
        - L'enemic Flame, et persegueix i quan est�s en el seu radi d'atac, et comen�a a dispara i es queda en una distancia de tu.
        - L'enemic Skull, et persegueix quan estiguis dins del radi de persecuci�, quan no ho �s torna a la seva posici� inicial. Et treu vida quan et toca i va m�s r�pid que flame.
    - A m�s, tenim una masmorra, a la qual s'accedeix entran per la cova de l'escena principal. All� et trobar�s enemics, curacions, monedes, altres pickups. i armes.
*/