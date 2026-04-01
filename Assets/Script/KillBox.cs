using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class KillBox : MonoBehaviour
{
    [SerializeField] private bool destroyGameObject = true;
    [SerializeField] private string playerTag = "Player";

    private void Reset()
    {
        var poly = GetComponent<PolygonCollider2D>();
        if (poly != null) poly.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(playerTag)) return;

        GameObject playerRoot = collision.rigidbody != null ? collision.rigidbody.gameObject : collision.gameObject;

        if (destroyGameObject)
            Destroy(playerRoot);
    }
}
