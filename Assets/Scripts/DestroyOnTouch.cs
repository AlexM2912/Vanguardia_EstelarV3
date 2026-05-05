using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El objeto fue destruido por: " + other.gameObject.name);
            Destroy(gameObject);
        }
    }
}
