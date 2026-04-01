using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class KillBox : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void Reset()
    {
        var poly = GetComponent<PolygonCollider2D>();
        if (poly != null) poly.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;

        // Cherche un PlayerHealth sur l'objet joueur (ou ses parents)
        var health = other.GetComponentInParent<PlayerHealth>();
        if (health != null)
        {
            health.Die();
            return;
        }

        // Sinon fallback : détruire le GameObject du joueur
        var root = other.attachedRigidbody != null ? other.attachedRigidbody.gameObject : other.gameObject;
        Destroy(root);
    }
}
