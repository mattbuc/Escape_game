using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    float push;
    public int Amount;
    Vector3 OriginalPosButton;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        push = -0.10f;
        OriginalPosButton = button.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(OriginalPosButton.x, OriginalPosButton.y, push);
            presser = other.gameObject; 
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            // Informer le gestionnaire central de l'appui sur ce bouton
            ButtonManager.Instance.ButtonPressed(this);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPressed)
        {
            button.transform.localPosition = new Vector3(OriginalPosButton.x, OriginalPosButton.y, OriginalPosButton.z);
            onRelease.Invoke();
            isPressed = false;

            // Informer le gestionnaire central du relâchement de ce bouton
            ButtonManager.Instance.ButtonReleased(this);

            // Debug.Log("Amount: " + Amount);

        }
    }


}
