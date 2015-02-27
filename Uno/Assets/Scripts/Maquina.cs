using UnityEngine;
using System.Collections;

public class Maquina : Jugador {


    public override void Juega()
    {

    }
    public override void Roba()
    {
        GameManager.manager.TomarCartaMazo(false);
    }

}
