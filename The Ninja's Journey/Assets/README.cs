/*
    - Quan el personatge perd vida, disminueix la seva velocitat de moviment.
    - Hi han monedes en el mapa per recol·lectar.
    - A més de les monedes com a pick-ups, també tenim picks ups curatius, fa que puguis recuperar una vida o tota depenent de la mida del cor.
    - També hi ha pickups de les armes per poder aconseguir aquesta (només dos d´implementades, de moment: arc i shuriken)
    - Hi ha dos tipus d'enemics que hem implemenent de moment:
        - L'enemic Skull, et persegueix quan estiguis dins del radi de persecució, quan no ho és torna a la seva posició inicial. Et treu vida quan et toca.
        - L'enemic Flame, et persegueix i quan estàs en el seu radi d'atac, et comença a dispara i es queda en una distancia de tu.
    - A més, tenim una masmorra, a la qual s'accedeix entran per la cova de l'escena principal. Allà et trobaràs enemics, curacions, monedes, altres pickups. i armes.
*/