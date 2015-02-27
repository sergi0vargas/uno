using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager manager;

    public List<Carta> mazo;
    public List<Carta> cartasMesa = new List<Carta>();
    public Carta dorso;
    public Carta cartaEnLaSimaDelMazo;
    public Carta cartaEnLaSimaDeLaMesa;
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
        OrganizarCartasInicial();
	}

    public void RepartirCartas()
    {
        if (mazo.Count <= 0)
            return;

        Carta temp;

        for (int i = 0; i < 4; i++)
        {
            //Agrega cartas al jugador
            temp = mazo[Random.Range(0, mazo.Count)];
            jugador.cartas.Add(temp);
            mazo.Remove(temp);

            //Agrega cartas a la maquina
            temp = mazo[Random.Range(0, mazo.Count)];
            maquina.cartas.Add(temp);
            mazo.Remove(temp);
            
        }
        //Agrega una carta a la mesa
        cartaEnLaSimaDeLaMesa = mazo[Random.Range(0, mazo.Count)];
        mazo.Remove(cartaEnLaSimaDeLaMesa);


        //Saca 1 carta del maso y la alista para ser tomada
        GeneraCartaSima();
        
    }

    void AgregarCartaALaMesa(Carta c)
    {
        cartasMesa.Add(cartaEnLaSimaDeLaMesa);
        cartaEnLaSimaDeLaMesa = c;
        OrganizaCartasMesa();
    }

    void GeneraCartaSima()
    {
        cartaEnLaSimaDelMazo = mazo[Random.Range(0, mazo.Count)];
        mazo.Remove(cartaEnLaSimaDelMazo);
    }

    public void OrganizarCartasInicial()
    {

        dorso.transform.position = posMazo.position;

        foreach (Carta c in mazo)
        {
            c.transform.position = posMazo.position;
            c.transform.rotation = posMazo.rotation;
        }
        foreach (Carta c in jugador.cartas)
        {
            c.transform.position = posJugador.position;
            c.transform.rotation = posJugador.rotation;
        }
        foreach (Carta c in maquina.cartas)
        {
            c.transform.position = posMaquina.position;
            c.transform.rotation = posMaquina.rotation;
        }

        foreach (Carta c in cartasMesa)
        {
            c.transform.position = posMesa.position;
            c.transform.rotation = posMesa.rotation;
        }

    }

    public void TomarCartaMazo(bool esJugador)
    {
        if (mazo.Count <= 0)
            return;

        if (esJugador)
        {
            jugador.cartas.Add(cartaEnLaSimaDelMazo);
            jugador.cantidadCartasActual++;
            GeneraCartaSima();
        }
        else
        {
            maquina.cartas.Add(cartaEnLaSimaDelMazo);
            maquina.cantidadCartasActual++;
            GeneraCartaSima();
        }
    }

    public void OrganizaCartasMesa()
    {
        for (int i = 0; i < cartasMesa.Count; i++)
        {
            cartasMesa[i].GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        cartaEnLaSimaDeLaMesa.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

}
