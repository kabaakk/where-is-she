using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public Slider staminaBar;
    public Slider healthBar;

    public int maxHealth = 100;
    public float currentHealth;

    public int maxStamina = 100;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static PlayerStats instance;

    public static PlayerMovement player;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if (currentStamina > 0)
        {
            currentStamina -= amount * Time.deltaTime;
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }

        else
        {
            Debug.Log("Not enough stamina");
        }
    }

    public void GetDamage(float amount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= amount;
            healthBar.value = currentHealth;
        }
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;

            yield return regenTick;
        }
        regen = null;
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("GameOver");
    }
}
