using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {

    public string Descrizione1 = "hsaiduhaiudyaiusdh";
    public string Descrizione2;
    public string Descrizione3;

    public Material material1;
    public Material material2;
    public Material material3;

    public GameObject Oggetto1;
    public GameObject Oggetto2;
    public GameObject Oggetto3;
    public GameObject Oggetto4;
    public GameObject Oggetto5;


    // Use this for initialization
    void Start () {
        ChangeName("xyz");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeName(string _par) {
        Oggetto1.name = _par;
        Oggetto2.name = _par;
        Oggetto3.name = _par;
        Oggetto4.name = _par;
        Oggetto5.name = _par;
    }
}
