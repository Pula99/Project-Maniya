using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    private float maxHealth = 100;
    public float currentHealth;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberofFlashes;
    private SpriteRenderer spriteRend;

    [Header("Component")]
    [SerializeField] private Behaviour[] components;
    private bool invulerable;
    private Animator anim;

    [Header("Player Death Sound")]
    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip HurtSound;



    [Header("other components")]
    public GameObject fallDetector;

    public UIManager uiManager;

    public int damage;
    private bool isDead;


    public HealthBar healthBar;
    void Start()
    {
        maxHealth = PlayerPrefs.GetFloat("Health");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        spriteRend = GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
    }

    public void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x , fallDetector.transform.position.y);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            Manager.instance.PlayerHealth.TakeDamage(damage);
            transform.position = Manager.instance.RespawnPoint.position;

        }
        else if (collision.tag == "Enemy")
        {
            Manager.instance.PlayerHealth.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        if (invulerable) return;

        currentHealth -= damage;
        SoundManager.instance.PlaySound(HurtSound);
        StartCoroutine(Invunerability());
        
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
           
            Destroy(gameObject,1f);
            SoundManager.instance.PlaySound(DeathSound);
            SoundManager.instance.BgSound.enabled = false;
            uiManager.GameOver();

            Time.timeScale = 0;

        }

    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
    }


    private IEnumerator Invunerability()
    {
        invulerable = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);

        for (int i = 0; i < numberofFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2 ));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(6, 7, false);
        invulerable = false;

    }

}
