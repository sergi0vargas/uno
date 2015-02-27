using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager manager;

    public List<Carta> mazo;

	// Use this for initialization
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
