using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour
{

    public GameObject ventilation;
    AudioSource sound;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        anim = ventilation.GetComponent<Animator>();

    }

    // Update is called once per frame
    private void GoodCodeNumpad()
    {
        sound.Play();
        anim.SetBool("isOn", true);
    }
}
