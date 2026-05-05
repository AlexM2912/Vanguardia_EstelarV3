using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damage = 1;
    public float damageCooldown = 1f;

    private float timer;

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        timer += Time.deltaTime;

        if (timer >= damageCooldown)
        {
            PlayerHealth ph = other.GetComponentInParent<PlayerHealth>();

            if (ph != null)
            {
                ph.TakeDamage(damage);
                Debug.Log("DAÑO DE SPIKE");
            }
            else
            {
                Debug.Log("NO ENCUENTRA PlayerHealth");
            }

            timer = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f;
        }
    }


}