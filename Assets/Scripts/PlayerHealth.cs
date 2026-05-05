using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 7;
    public int health;

    [Header("Renderers")]
    public SpriteRenderer playerSr;
    public SpriteRenderer armSr;
    public SpriteRenderer weaponSr;

    [Header("UI")]
    public HealthDisplay healthDisplay;

    [Header("Invulnerabilidad")]
    public float invulnerabilityTime = 0.5f;

    private float invulTimer;

    private PlayerController controller;

    void Start()
    {
        health = maxHealth;
        controller = GetComponent<PlayerController>();

        if (healthDisplay != null)
            healthDisplay.UpdateHearts(health, maxHealth);
    }

    void Update()
    {
        if (invulTimer > 0f)
            invulTimer -= Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {
        // Evita daño continuo inmediato
        if (invulTimer > 0f) return;

        health -= amount;
        invulTimer = invulnerabilityTime;

        Debug.Log("Vida actual: " + health);

        // Actualizar UI
        if (healthDisplay != null)
            healthDisplay.UpdateHearts(health, maxHealth);

        // Muerte
        if (health <= 0)
        {
            health = 0;

            if (playerSr != null) playerSr.enabled = false;
            if (armSr != null) armSr.enabled = false;
            if (weaponSr != null) weaponSr.enabled = false;

            if (controller != null)
                controller.enabled = false;
        }
    }
}