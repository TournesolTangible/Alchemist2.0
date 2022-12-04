/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{

    private bool isInvincible = false; // for invincibility
    [SerializeField] public float invincibilityDurationInSec = 2.0f;

    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    #region Sigleton
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerStats>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health = 3.0f;
    [SerializeField]
    private float maxHealth = 3.0f;
    [SerializeField]
    private float maxTotalHealth = 10.0f;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {

        if(isInvincible) return; // do nothing if you are invincible

        health -= dmg;
        ClampHealth();

        StartCoroutine(BecomeInvincible()); // become invincible
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }   
    }

    public float ReturnHealth() {
        return health;
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    // adding stuff for invulnerability on taking damage

    private IEnumerator BecomeInvincible() {
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityDurationInSec);

        isInvincible = false;
    }

    void methodToTriggerInvincibility() {
        if (!isInvincible) {
            StartCoroutine(BecomeInvincible());
        }
    }


}
