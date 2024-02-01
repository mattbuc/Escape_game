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


            boule.transform.localPosition = new Vector3(OriginalPosBoule.x, OriginalPosBoule.y, OriginalPosBoule.z);

        }

    


}
