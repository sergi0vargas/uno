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

    public override bool CheckTieneCartaCorrectaEnMano()
    {
        bool tieneCarta = false;
        foreach (Carta c in cartas)
        {
            if (GameManager.manager.cartaEnLaSimaDeLaMesa.esRojo == c.esRojo)
            {
                tieneCarta = true;
            }
            if (GameManager.manager.cartaEnLaSimaDeLaMesa.valor == c.valor)
            {
                tieneCarta = true;
            }
        }
        return tieneCarta;
    }

}
