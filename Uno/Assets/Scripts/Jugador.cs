using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Jugador : MonoBehaviour {

    public List<Carta> cartas = new List<Carta>();

    public int puntaje = 0;

    public int cantidadCartasActual = 0;

    public bool yaRobo = false;

    public bool tieneCartaQueSirve;
    public bool yaChequeo = false;

    //public bool maquina = false; //no hace falta

	public abstract void Juega();
    public abstract void Roba();

    public void ComienzoDeTurno()
    {
        tieneCartaQueSirve = CheckTieneCartaCorrectaEnMano();
        yaChequeo = true;
    }

    public abstract bool CheckTieneCartaCorrectaEnMano();

    public void FinDeTurno()
    {
        yaRobo = false;
        yaChequeo = false;
    }

    public virtual void BuscarCarta(Carta c) { }

}
