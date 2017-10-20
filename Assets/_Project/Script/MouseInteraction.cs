using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour {

    public bool Unbreackable;

    public int Speed = 10;
    public string ModelName = "";
    public bool IsSold = false;
    public float Float = 0.454f;

    private bool HaStampato;

    private void OnEnable() {
        
    }

    private void Update() {
        Float = Float + 0.002f;
    }

    // Use this for initialization
    void Start() {
        HaStampato = false;
        HaStampato = StampaDati();
        Debug.Log("Risultato della stampa: " + HaStampato);
    }

    private void OnMouseOver() {
        if (Unbreackable == true) {
            return;
        }
        Debug.Log("Interaction");
        Destroy(gameObject);
    }

    bool StampaDati() {
        if (ModelName == "") {
            return false;
        }
        Debug.Log("Auto " + ModelName + " Speed: " + Speed);
        return true;
    }

    bool Limitatore() {
        if (Speed > 50 && Speed < 70) {
            return true;
        } else if (Speed < 0 || Speed > 100000) {
            return true;
        } else {

        }
        return false;
    }

    float Accellera() {
        if (Limitatore() == true) {
            Speed = Speed + 1;
        }
       
        return Speed;
    }

}
