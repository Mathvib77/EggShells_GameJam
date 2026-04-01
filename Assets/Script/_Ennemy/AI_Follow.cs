using Unity.VisualScripting;
using UnityEngine;

public class AI_Follow : MonoBehaviour
{
    [Tooltip("Référence au joueur (_Chara). Si vide, sera cherché automatiquement.")]
    [SerializeField] private GameObject player;

    [Tooltip("Vitesse de suivi unique pour cet ennemi (modifiable dans l'inspector).")]
    [SerializeField] private float followSpeed = 1f;

    [Tooltip("Distance à partir de laquelle l'ennemi commence à suivre le joueur.")]
    [SerializeField] private float followDistance = 15f;

    // Distance actuelle (visible dans l'inspector si besoin)
    [SerializeField] private float distance;

    private void Start()
    {
        if (player == null)
            player = GameObject.Find("_Chara");
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.name == "_Chara")
        {
            Destroy(collision.gameObject);
        }
    }

    // FixedUpdate pour la physique
    void FixedUpdate()
    {
        if (player == null) return;

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance > followDistance)
        {
            // Hors portée : ne bouge pas
            return;
        }

        // Dans la distance : utilise la vitesse configurée dans l'inspector
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    // Accès public si tu veux modifier la vitesse par code
    public float Speed
    {
        get => followSpeed;
        set => followSpeed = value;
    }
}
