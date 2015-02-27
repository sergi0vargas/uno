using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Jugador : MonoBehaviour {

    public List<Carta> cartas = new List<Carta>();

    public int puntaje = 0;

    public bool maquina = false;

	public abstract void Juega();
    public abstract void Roba();

}
