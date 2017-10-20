using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MouseOverAnimation : MonoBehaviour {

    [Tooltip("Indicare il nome parametro booleano dell'animation controller che controlla l'animazione all'OnMouseOver.")]
    public string OverAnimationParameterName;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver() {
        anim.SetBool("Open", true);
    }

    private void OnMouseExit() {
        anim.SetBool("Open", false);
    }
}
