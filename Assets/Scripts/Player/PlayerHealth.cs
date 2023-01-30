using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private float maxHealth = 100;
    public float currentHealth;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberofFlashes;
    private SpriteRenderer spriteRend;

    [Header("Component")]
    private bool invulerable;
    private Animator anim;

    private Vector3 respawnPoint;
    public GameObject fallDetector;



    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        spriteRend = GetComponent<SpriteRenderer>();
        respawnPoint = transform.position;
    }

    public void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x , fallDetector.transform.position.y);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;

        } else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
            
        } 
    }


    public void TakeDamage(float damage)
    {
        if (invulerable) return;

        currentHealth -= damage;
        StartCoroutine(Invunerability());
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {   
            Destroy(gameObject);

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
