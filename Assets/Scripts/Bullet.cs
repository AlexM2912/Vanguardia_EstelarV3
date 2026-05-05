using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Start()
    {
        // Asegura que la dirección esté bien al salir
        transform.right = transform.right;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TOCÓ: " + other.name);

        if (other.CompareTag("Enemy"))  
        {
            EnemyDamage enemy = other.GetComponent<EnemyDamage>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLISION: " + collision.gameObject.name);

        EnemyDamage enemy = collision.gameObject.GetComponent<EnemyDamage>();

        if (enemy == null)
            enemy = collision.gameObject.GetComponentInParent<EnemyDamage>();

        if (enemy != null)
        {
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}