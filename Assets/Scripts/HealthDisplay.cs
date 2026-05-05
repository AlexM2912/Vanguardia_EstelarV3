using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public PlayerHealth playerHealth;

    void Awake()
    {
        // 1) intenta tomarlo del propio objeto
        if (playerHealth == null)
            playerHealth = GetComponent<PlayerHealth>();

        // 2) intenta buscar en el Player de la escena
        if (playerHealth == null)
        {
            var player = GameObject.FindWithTag("Player");
            if (player != null)
                playerHealth = player.GetComponent<PlayerHealth>();
        }

        // 3) último recurso
        if (playerHealth == null)
            playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth == null) return;

        int currentHealth = Mathf.Clamp(playerHealth.health, 0, hearts.Length);

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void UpdateHearts(int health, int maxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            hearts[i].enabled = (i < maxHealth);
        }
    }
}