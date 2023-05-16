/*
    - Els checkpoints ara són visibles perquè hem estat provant el seu funcionament.
    - Quan el personatge perd vida, disminueix la seva velocitat de moviment.
    - Hi ha monedes en el mapa per recol·lecta i et sumaran la puntuació.
    - A més de les monedes com a pick-ups, també tenim picks-ups curatius, fa que puguis recuperar una vida o tota depenent del mida del cor.
        - També hi ha pick-ups de les armes per poder aconseguir aquesta (només dos d'implementades, de moment: arc i shuriken)
    - Hi ha dos tipus d'enemics que hem implementant de moment:
        - L'enemic Skull, que et persegueix quan et veu i estiguis dins del seu radi de persecució, i et treu vida quan et toca.
        - L'enemic Flame, que et persegueix i quan estàs en el seu radi d'atac, et comença a disparar i es queda en una distància de tu.
    - A més, tenim una masmorra, a la qual s'accedeix entrant per la cova de l'escena principal. Allà et trobaràs enemics, curacions, monedes, altres pick-ups.
*/