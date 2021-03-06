﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zampediverse.UnityToolkit {

    public class MouseOverAnimation : MonoBehaviour {

        [Tooltip("Indicare il nome del parametro booleano dell'animation controller che controlla l'animazione all'OnMouseOver. Se non indicato il parametro di default sarà 'Open'")]
        public string OverAnimationParameterName;
        public Animator anim;

        // Use this for initialization
        void Start() {
            // anim = GetComponent<Animator>();
            if (OverAnimationParameterName == "")
                OverAnimationParameterName = "Open";
        }


        private void OnMouseOver() {
            anim.SetBool(OverAnimationParameterName, true);
        }

        private void OnMouseExit() {
            anim.SetBool(OverAnimationParameterName, false);
        }
    }
}