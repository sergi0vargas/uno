using UnityEngine;
using System.Collections;

public class Player : Jugador {


    public Carta cartaSeleccionada;

    public override void Juega()
    {

    }
    public override void Roba()
    {
        GameManager.manager.TomarCartaMazo(true);
    }

    public bool CheckTieneCartaCorrectaEnMano()
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

        if (cartaSeleccionada != null)
        {
            if (GameManager.manager.cartaEnLaSimaDeLaMesa.esRojo == cartaSeleccionada.esRojo)
                tieneCarta = true;
            if (GameManager.manager.cartaEnLaSimaDeLaMesa.valor == cartaSeleccionada.valor)
                tieneCarta = true;
        }

        return tieneCarta;
    }

    public void BuscarCarta(Carta c)
    {
        if (cartas.Contains(c))
        {
            if (cartaSeleccionada != null)
                cartas.Add(cartaSeleccionada);    
            cartaSeleccionada = cartas[cartas.IndexOf(c)];
            cartas.Remove(cartaSeleccionada);
        }
    }
}
