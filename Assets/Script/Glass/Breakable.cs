using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Breakable : MonoBehaviour
{
    
    [SerializeField] GameObject glass;
    [SerializeField] GameObject brokenGlass;
    public GameObject stone;

    BoxCollider boxCollider;

    private void Awake()
    {
        glass.SetActive(true);
        brokenGlass.SetActive(false);

        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider stone)
    {
        if (stone.gameObject.name == "caillou")
        {
            Break();
            Debug.Log("Breakable object broken!");
        }
    }


    private void Break()
    {
        glass.SetActive(false);
        brokenGlass.SetActive(true);
        boxCollider.enabled = false;
    }
}
