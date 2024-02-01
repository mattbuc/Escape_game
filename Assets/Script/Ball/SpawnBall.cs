using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class SpawnBall : MonoBehaviour
{
    
    [SerializeField] GameObject boule;
    [SerializeField] GameObject zoneFall;
    [SerializeField] GameObject respawnPoint;
    Vector3 OriginalPosBoule;

    BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        OriginalPosBoule = boule.transform.localPosition;
    }

    private void OnTriggerEnter(Collider boule)
    {
        Debug.Log("Collision detected with: " + boule.gameObject.name);
        if (boule.gameObject.name == "Balle" || boule.gameObject.name == "Sphere")
        {
            respawn();
            Debug.Log("spawn");
        }
    }


    private void respawn()
    {
        Rigidbody bouleRigidbody = boule.GetComponent<Rigidbody>();

        if (bouleRigidbody.isKinematic == false)
        {
            bouleRigidbody.isKinematic = true;
            bouleRigidbody.useGravity = false;
            boule.transform.localPosition = new Vector3(OriginalPosBoule.x, OriginalPosBoule.y, OriginalPosBoule.z);
            Invoke("Fall", 2f);
        }

    }

    void Fall()
    {
        Rigidbody bouleRigidbody = boule.GetComponent<Rigidbody>();
        bouleRigidbody.isKinematic = false;
        bouleRigidbody.useGravity = true;
    }
}
