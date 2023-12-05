using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    public GameObject button;
    public GameObject buttonSign;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;


    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0, -0.09f);
            buttonSign.transform.localPosition = new Vector3(1.950179f, -0.02342248f, -0.12f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
            Debug.Log("Button Pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0, 0);
            buttonSign.transform.localPosition = new Vector3(1.950179f, -0.02342248f, -0.03257556f);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void test()
    {
        Debug.Log("Button DePressed");
    }
}
