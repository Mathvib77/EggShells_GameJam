using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        public float speed = 5f;
        public float rotationSpeed = 720f; 

    float velX = 0f;

    bool bTouched = false;

    private void Update()
    {
        if (!bTouched) velX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (!bTouched)
        {
            // Move the player forward
            transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
            // Rotate the player based on horizontal input  
        }

        transform.Rotate(Vector3.forward, -velX * rotationSpeed * Time.fixedDeltaTime);

    }

    IEnumerator ResetTouch()
    {
        float timer = 0f;
        while (timer < 0.25f)
        {
            transform.Rotate(Vector3.forward, 180/100);
            timer += Time.deltaTime;
            Debug.Log(timer);
            yield return new WaitForEndOfFrame();
        }
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        
        bTouched = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bTouched = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * 15f, ForceMode2D.Impulse);

        StartCoroutine(ResetTouch());
    }
}
