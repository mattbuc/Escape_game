using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NumpadScript : MonoBehaviour
{
    public int[] buttonIndices = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    private XRController xrController;

    private void Start()
    {
        // Assurez-vous que le composant XRController est attaché à cet objet
        xrController = GetComponent<XRController>();
        if (xrController == null)
        {
            Debug.LogError("Le composant XRController est manquant sur cet objet.");
        }
    }

    private void Update()
    {
        // Vérifiez l'interaction avec la gâchette
        if (xrController != null && IsTriggerPressed())
        {
            // Obtenir l'index du bouton sur lequel on a appuyé
            int buttonIndex = GetNearestButtonIndex();

            // Afficher un message dans la console avec l'index du bouton
            Debug.Log("Bouton appuyé : " + buttonIndex);
        }
    }

    private bool IsTriggerPressed()
    {
        // Vérifiez si le bouton de la gâchette est enfoncé
        return xrController.inputDevice.IsPressed(InputHelpers.Button.Trigger, out bool triggerValue) && triggerValue;
    }

    private int GetNearestButtonIndex()
    {
        // Ajouter votre logique ici pour déterminer quel bouton est appuyé
        // Utilisez des rayons, des collisions, ou d'autres méthodes selon vos besoins.

        float minDistance = float.MaxValue;
        int nearestButtonIndex = -1;

        foreach (int buttonIndex in buttonIndices)
        {
            // Remplacez le code ci-dessous par votre propre logique pour obtenir la position du bouton
            Vector3 buttonPosition = Vector3.zero;

            float distance = Vector3.Distance(transform.position, buttonPosition);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestButtonIndex = buttonIndex;
            }
        }

        return nearestButtonIndex;
    }
}
