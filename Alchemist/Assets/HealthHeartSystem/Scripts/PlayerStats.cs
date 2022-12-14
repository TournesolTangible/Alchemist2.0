/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{

    private bool isInvincible = false; // for invincibility
    [SerializeField] public float invincibilityDurationInSec = 2.0f;

    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    // holds the hurt sounds
    [SerializeField] private List<AudioSource> _HurtSounds;

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
    public float health = 3.0f;
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

        // play hurt sound
        if (Health == 1) {
            _HurtSounds[2].Play();
        } else {
            _HurtSounds[Random.Range(0,2)].Play();
        }
        

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

        // set alpha to half while invincible
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = .5f;
        this.GetComponent<SpriteRenderer>().color = tmp;

        yield return new WaitForSeconds(invincibilityDurationInSec);

        // set alpha back to full when vulnerable again
        tmp.a = 1f;
        this.GetComponent<SpriteRenderer>().color = tmp;

        isInvincible = false; 
    }

    void methodToTriggerInvincibility() {
        if (!isInvincible) {
            StartCoroutine(BecomeInvincible());

        }
    }


}
