using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;


public class ButtonHide : MonoBehaviour
{
    public GameObject buttonHide;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;        
    float push;
    Vector3 OriginalPosButton;
    public GameObject mancheHache;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        push = -1.497f;
        OriginalPosButton = buttonHide.transform.localPosition;
    }

   private void OnTriggerEnter(Collider other)
    {

        if (!isPressed)
        {
            buttonHide.transform.localPosition = new Vector3(OriginalPosButton.x, OriginalPosButton.y, push);
            presser = other.gameObject; 
            onPress.Invoke();
            sound.Play();
            isPressed = true;
            Invoke("MancheHache", 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPressed)
        {
            onRelease.Invoke();
            isPressed = false;

        }
    }

    void MancheHache()
    {
            Rigidbody mancheRigidbody = mancheHache.GetComponent<Rigidbody>();

    // Assurez-vous que le composant Rigidbody est présent
    if (mancheRigidbody != null)
    {
        // Désactivez la propriété isKinematic
        mancheRigidbody.isKinematic = false;

        // Activez la gravité
        mancheRigidbody.useGravity = true;
        Debug.Log("Manche de hache récupéré");
        
    }
    }
}
