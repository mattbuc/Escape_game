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
    float testPush;

    Vector3 OriginalPosButton;
    Vector3 OriginalPosButtonSign;


    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        testPush = -0.12f;
        OriginalPosButton = button.transform.localPosition;
        OriginalPosButtonSign = buttonSign.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(OriginalPosButton.x, OriginalPosButton.y, -0.09f);
            buttonSign.transform.localPosition = new Vector3(OriginalPosButtonSign.x, OriginalPosButtonSign.y, testPush);
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
            button.transform.localPosition = new Vector3(OriginalPosButton.x, OriginalPosButton.y, OriginalPosButton.z);
            buttonSign.transform.localPosition = new Vector3(OriginalPosButtonSign.x, OriginalPosButtonSign.y, OriginalPosButtonSign.z);
            onRelease.Invoke();
            isPressed = false;
            Debug.Log("Button UnPressed");
        }
    }

    public void test()
    {
        Debug.Log("Button DePressed");
    }

}
