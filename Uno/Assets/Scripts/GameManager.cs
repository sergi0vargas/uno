using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager manager;

    public List<Carta> mazo;
    public List<Carta> cartasMesa = new List<Carta>();
    public Carta dorso;
    //CARTAS DE LOS JUGADORES
    public Jugador jugador;
    public Jugador maquina;

    //Posicion de las cartas
    public Transform posMazo;
    public Transform posMesa;
    public Transform posJugador;
    public Transform posMaquina;
    
	void Awake () {
        //SINGLETON
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }

	}
	

	void Start () {

        RepartirCartas();
	}

    public void RepartirCartas()
    {
        if (mazo.Count <= 0)
            return;

        Carta temp;

        for (int i = 0; i < 4; i++)
        {
            temp = mazo[Random.Range(0, mazo.Count)];
            jugador.cartas.Add(temp);
            mazo.Remove(temp);
            Debug.Log("Agregada carta #" + i + " a jugador");

            temp = mazo[Random.Range(0, mazo.Count)];
            maquina.cartas.Add(temp);
            mazo.Remove(temp);
            Debug.Log("Agregada carta #" + i + " a la maquina");
            
        }

        temp = mazo[Random.Range(0, mazo.Count)];
        cartasMesa.Add(temp);
        mazo.Remove(temp);
        Debug.Log("Agregada carta a la mesa");

    }

    public void OrganizarCartasInicial()
    {

        foreach (Carta c in mazo)
        {

        }
        foreach (Carta c in cartasMesa)
        {

        }
        foreach (Carta c in jugador.cartas)
        {

        }
        foreach (Carta c in maquina.cartas)
        {

        }

    }

}
