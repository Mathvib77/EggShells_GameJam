using UnityEngine;
using System.Collections.Generic;

public class ZoneMults : MonoBehaviour
{
    [Tooltip("Multiplicateur appliqué lorsque _Chara est dans cette zone")]
    [SerializeField] private float multiplier = 1.2f;

    // Liste des zones actuellement traversées par _Chara 
    private static readonly List<ZoneMults> activeZones = new List<ZoneMults>();

    // Multiplicateur actif global consultable par le compteur de points
    public static float CurrentMultiplier { get; private set; } = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "_Chara") return;

        // Ajoute la zone en fin de liste (dernier entré = priorité)
        activeZones.Add(this);
        CurrentMultiplier = multiplier;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name != "_Chara") return;

        // Retire la zone de la liste
        activeZones.Remove(this);

        // Si d'autres zones sont encore actives, applique le multiplicateur de la dernière entrée
        if (activeZones.Count > 0)
            CurrentMultiplier = activeZones[activeZones.Count - 1].multiplier;
        else
            CurrentMultiplier = 1f; // pas de zone => multiplicateur par défaut
    }

    // Accès en lecture au multiplicateur
    public float Multiplier => multiplier;
}
