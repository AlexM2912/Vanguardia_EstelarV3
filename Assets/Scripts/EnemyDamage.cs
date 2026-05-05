using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 2;
    private int health;

    [Header("Daño al jugador")]
    public int damage = 1;
    public float damageCooldown = 1f;

    private float timer;

    private PlayerHealth playerHealth;

    void Start()
    {
        health = maxHealth;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        timer += Time.deltaTime;

        if (timer >= damageCooldown && playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            timer = 0f;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timer = 0f;
        }
    }
}