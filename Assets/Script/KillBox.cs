using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KillBox : MonoBehaviour
{
    [SerializeField] private bool destroyGameObject = true;
    [SerializeField] private string playerTag = "Player";


    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    
}
