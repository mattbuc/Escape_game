using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Video;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private List<ButtonVR> pressedButtons = new List<ButtonVR>();
    private List<int> targetSequence = new List<int> { 6, 1, 5, 9};
    private List<int> trollSequence = new List<int> { 1, 2, 3 ,4};

    public GameObject television;

    public GameObject ventilation;
    AudioSource soundVentilation;
    Animator animVentilation;

    public GameObject lameHache;


    private bool isPlaying = true;

    // Propriété statique pour l'instance unique du gestionnaire
    private static ButtonManager _instance;


    public static ButtonManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Recherchez l'instance existante dans la scène
                _instance = FindObjectOfType<ButtonManager>();
            }
            return _instance;
        }
    }


    public void ButtonPressed(ButtonVR button)
    {
        pressedButtons.Add(button);
        CheckButtonSequence();
        Debug.Log("Button pressed: " + button.Amount);
    }

        // Appelé lorsque le bouton est relâché
    public void ButtonReleased(ButtonVR button)
    {
        // Implémentez le code à exécuter lorsqu'un bouton est relâché
    }

     // Vérifie si les boutons 1, 2, 3, 4 ont été pressés dans l'ordre
    private void CheckButtonSequence()
    {
        // Récupérez la séquence des Amounts depuis la liste de boutons pressés
        List<int> currentSequence = pressedButtons.Select(button => button.Amount).ToList();

        // Vérifiez si la séquence actuelle correspond à la séquence cible
        if (currentSequence.SequenceEqual(targetSequence))
        {   

            Invoke("OpenVent", 2f);
            Invoke("FallAxe", 3f);
            Debug.Log("Sequence complete! Do something special.");
            // Réinitialisez la liste des boutons pressés pour la prochaine séquence
            pressedButtons.Clear();
        }
        else if (currentSequence.SequenceEqual(trollSequence))
        {
            
            Invoke("PlayVideoOnTelevision", 2f);
            Debug.Log("Sequence troll! Do something special.");
            pressedButtons.Clear();
        }
                else if (currentSequence.Count >= targetSequence.Count)
        {
            Debug.Log("Sequence failed! Try again.");
            // Réinitialisez la liste des boutons pressés pour la prochaine séquence
            pressedButtons.Clear();

        }
    }

    void PlayVideoOnTelevision()
    {
        if (isPlaying)
        {
            television.GetComponent<VideoPlayer>().Play();
            // Arrête la vidéo après un délai de 10 secondes
            Invoke("StopVideoOnTelevision", 10f);
        }

    }

    void OpenVent()
    {
        ventilation.GetComponent<AudioSource>().Play();
        ventilation.GetComponent<Animator>().SetBool("isOn", true);


    }

    void FallAxe()
    {
    // Récupérez le composant Rigidbody de la lame de la hache
    Rigidbody lameRigidbody = lameHache.GetComponent<Rigidbody>();

    // Assurez-vous que le composant Rigidbody est présent
    if (lameRigidbody != null)
    {
        // Désactivez la propriété isKinematic
        lameRigidbody.isKinematic = false;

        // Activez la gravité
        lameRigidbody.useGravity = true;
    }

    }

    // Méthode appelée après un délai de 10 secondes pour arrêter la vidéo
    void StopVideoOnTelevision()
    {
        isPlaying = false;
        television.GetComponent<VideoPlayer>().Stop();
    }

}
