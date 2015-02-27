using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager manager;

    public bool turnoJugador = true;


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


    /// GUIIIIIII MIERDA!!!

    public Text puntajePlayer;
    public Text puntajeMaquina;
    public Text cartasActualesMazo;
    public Text cartasActualesJugador;
    public Text cartasActualesMaquina;

    /*GUIIIIIII MIERDA!!!
     * */

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


    void Update()
    {
        //CAMBIAR!!! SOLO DEBE ACTUALIZARSE EN CADA MOVIDA
        puntajePlayer.text = "Puntaje Jugador: " + jugador.puntaje;
        puntajeMaquina.text = "Puntaje Maquina: " + maquina.puntaje;
        cartasActualesJugador.text = "Cartas Actuales: " + jugador.cantidadCartasActual;
        cartasActualesMaquina.text = "Cartas Actuales: " + maquina.cantidadCartasActual;
        cartasActualesMazo.text = "Cartas en Mazo: " + mazo.Count;

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
                Debug.Log("TOCO A: " + hit.transform.name);

        }

        if (turnoJugador)
        {

        }
        else
        {

        }


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
            jugador.cantidadCartasActual++;

            //Agrega cartas a la maquina
            temp = mazo[Random.Range(0, mazo.Count)];
            maquina.cartas.Add(temp);
            mazo.Remove(temp);
            maquina.cantidadCartasActual++;
            
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
        int i = 1;
        foreach (Carta c in jugador.cartas)
        {
            c.transform.position = posJugador.position + (new Vector3(posJugador.position.x + i, 0, 0));
            c.transform.rotation = posJugador.rotation;
            i*=2;
        }
        i = 1;
        foreach (Carta c in maquina.cartas)
        {
            c.transform.position = posMaquina.position + (new Vector3(posJugador.position.x + i, 0, 0));
            c.transform.rotation = posMaquina.rotation;
            i *= 2;
        }

        foreach (Carta c in cartasMesa)
        {
            c.transform.position = posMesa.position;
            c.transform.rotation = posMesa.rotation;
        }
        cartaEnLaSimaDeLaMesa.transform.position = posMesa.position;
        cartaEnLaSimaDeLaMesa.transform.rotation = posMesa.rotation;

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
