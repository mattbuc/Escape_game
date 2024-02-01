using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicVolumeController : MonoBehaviour
{
    // Ajoutez le AudioSource qui joue la musique sur cet objet
    public AudioSource musicSource;

    void Start()
    {
        // Abonnez la méthode AdjustVolume à l'événement SceneLoaded
        SceneManager.sceneLoaded += AdjustVolume;
    }

    void AdjustVolume(Scene scene, LoadSceneMode mode)
    {
        // Ajustez le volume de la musique ici en fonction de la scène chargée
        if (scene.name == "NomDeLaSceneAvecVolumeRéduit")
        {
            musicSource.volume = 0.5f; // Ajustez la valeur du volume selon vos besoins
        }
        else
        {
            musicSource.volume = 1f; // Rétablissez le volume à sa valeur normale pour les autres scènes
        }
    }
}
