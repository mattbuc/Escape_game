using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private List<ButtonVR> pressedButtons = new List<ButtonVR>();
    private List<int> targetSequence = new List<int> { 1, 2, 3, 4 };

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
        Debug.Log("Sequence complete! Do something special.");
        // Réinitialisez la liste des boutons pressés pour la prochaine séquence
        pressedButtons.Clear();
    }
    else if (currentSequence.Count >= targetSequence.Count)
    {
        Debug.Log("Sequence failed! Try again.");
        // Réinitialisez la liste des boutons pressés pour la prochaine séquence
        pressedButtons.Clear();
    }
}

}
