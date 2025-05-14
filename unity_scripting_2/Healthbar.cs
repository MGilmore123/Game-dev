public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public UnityEngine.UI.Image healthBarFill;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }
}
