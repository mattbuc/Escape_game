using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[SelectionBase]

public class BreakingDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject doorBroken1;
    [SerializeField] GameObject doorBroken2;
    [SerializeField] GameObject doorBroken3;
    public GameObject Axe;

    BoxCollider boxCollider;


    private void Awake()
    {
        door.SetActive(true);
        doorBroken1.SetActive(false);
        doorBroken2.SetActive(false);
        doorBroken3.SetActive(false);

        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider Axe)
    {
        Debug.Log("Collision detected with: " + Axe.gameObject.name);
        if (Axe.gameObject.name == "SnapPoint")
        {
            Break();
            Debug.Log("Breakable object broken!");
        }
    }

        private void Break()
    {



        if (door.activeSelf == true)
        {
            door.SetActive(false);
            doorBroken1.SetActive(true);
            Debug.Log("premiere porte!");
            return;
        }
        else if (doorBroken1.activeSelf == true)
        {
            doorBroken1.SetActive(false);
            doorBroken2.SetActive(true);
            Debug.Log("Deuxieme porte!");
            return;
        }
        else if (doorBroken2.activeSelf == true)
        {
            doorBroken2.SetActive(false);
            doorBroken3.SetActive(true);
            Debug.Log("Troisieme porte!");
            return;
        }
        else if (doorBroken3.activeSelf == true)
        {
            doorBroken3.SetActive(false);
            boxCollider.enabled = false;
            Debug.Log("Troisieme porte!");

            LoadNextScene();
    
        }

        
    }

    private void LoadNextScene()
    {
        // Utilisez SceneManager pour charger la prochaine scène
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Assurez-vous que la scène suivante existe dans la Build Settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("La scène suivante n'existe pas dans la Build Settings.");
        }
    }

}
