using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zampediverse.UnityToolkit {

    /// <summary>
    /// Questa classe permette di far partire un'animazione dell'animator indicato in "anim".
    /// </summary>
    public class InteractForAnimation : MonoBehaviour {

        [Tooltip("Indicare il nome del parametro booleano dell'animation controller che controlla l'animazione all'OnMouseOver. Se non indicato il parametro di default sarà 'IsOpen'")]
        public string OverAnimationParameterName;
        [Tooltip("Indicare qual'è l'animator che comanderà l'animazione")]
        public Animator anim;
        [Tooltip("Indicare se c'è un'interazione automatica con un'azione del mouse")]
        public MouseInteractionType MouseInteraction = MouseInteractionType.None;
        [Tooltip("Indicare se sono ammesse le interazioni comandate da altri script tramite la funzione 'Interact'")]
        public bool EnableExternalInteractions = true;

        // Use this for initialization
        void Start() {
            // anim = GetComponent<Animator>();
            if (OverAnimationParameterName == "")
                OverAnimationParameterName = "IsOpen";
        }

        #region Mouse Click section

        private void OnMouseDown() {
            if (MouseInteraction != MouseInteractionType.MouseClick)
                return;
            if(anim.GetBool(OverAnimationParameterName) == false) {
                doInteract(true);
            } else {
                doInteract(false);
            }
            
        }

        #endregion

        #region MouseOver section

        private void OnMouseOver() {
            if (MouseInteraction != MouseInteractionType.MouseOver)
                return;
            doInteract(true);
        }

        private void OnMouseExit() {
            if (MouseInteraction != MouseInteractionType.MouseOver)
                return;
            doInteract(true);
        }

        #endregion

        #region Collider

        private void OnTriggerEnter(Collider other) {
            if (MouseInteraction != MouseInteractionType.Collision)
                return;
            doInteract(true);
        }

        private void OnTriggerStay(Collider other) {
            if (MouseInteraction != MouseInteractionType.Collision)
                return;
            doInteract(true);
        }

        private void OnTriggerExit(Collider other) {
            if (MouseInteraction != MouseInteractionType.Collision)
                return;
            doInteract(false);
        }

        //private void OnCollisionEnter(Collision collision) {
        //    if (MouseInteraction != MouseInteractionType.Collision)
        //        return;
        //    doInteract(true);
        //}

        //private void OnCollisionExit(Collision collision) {
        //    if (MouseInteraction != MouseInteractionType.Collision)
        //        return;
        //    doInteract(false);
        //}

        #endregion

        #region External interaction

        /// <summary>
        /// Funzione da richiamare se si vuole comandare l'animazione da uno script esterno.
        /// Se è true EnableExternalInteractions verrà chiamata la funzione interna.
        /// </summary>
        /// <param name="_open">Se true, indica che è un'interazione di apertura.</param>
        public bool Interact(bool _open) {
            if (EnableExternalInteractions == false)
                return false;
            doInteract(_open);
            return true;
        }

        /// <summary>
        /// Setta lo stato opposto a quello attuale.
        /// Se è true EnableExternalInteractions verrà chiamata la funzione interna.
        /// </summary>
        public bool InteractionToggle() {
            if (EnableExternalInteractions == false)
                return false;
            doInteractionToggle();
            return true;
        }

        /// <summary>
        /// Questa funzione permette ad altri oggetti esterni che collidono con questo, se sono è abilitatata l'external collision.
        /// (usata ad evempio per evitare che parta il contatore del mirino se collide con un oggetto non abilitato)
        /// </summary>
        /// <returns></returns>
        public bool CanInteract() {
            return EnableExternalInteractions;
        }

        #endregion

        #region Funzioni interne

        /// <summary>
        /// Setta lo stato indicato in <paramref name="_open"/> all'animator.
        /// </summary>
        /// <param name="_open">Se true, indica che è un'interazione di apertura.</param>
        void doInteract(bool _open) {
            anim.SetBool(OverAnimationParameterName, _open);
        }


        /// <summary>
        /// Setta lo stato opposto a quello attuale.
        /// </summary>
        void doInteractionToggle() {
            if (anim.GetBool(OverAnimationParameterName) == false) {
                doInteract(true);
            } else {
                doInteract(false);
            }
        }

        #endregion


        /// <summary>
        /// Tipi di interazione automatiche con mouse possibili.
        /// </summary>
        public enum MouseInteractionType {
            None,
            MouseOver,
            MouseClick,
            Collision,
        }
      
    }
}