
using UnityEngine;

public class DoomsDayLeftRight : MonoBehaviour
{
    [Header("doomsDay Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    private float checkTimer;
    private Vector3 destination;
    [SerializeField] private LayerMask playerLayer; 
    private bool attaking;
    private Vector3[] direction = new Vector3[4];

    [Header("Dooms Day life")]
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    [SerializeField] public GameObject deathEffect;

    void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        //move doomsday ti destination only if attacking
        if(attaking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();

        //check if doomsday sees player in all 4 directions
        for ( int i = 0; i < direction.Length; i++)
        {
            Debug.DrawRay(transform.position, direction[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction[i], range, playerLayer);

            if(hit.collider != null && !attaking)
            {
                attaking = true;
                destination = direction[i];
                checkTimer = 0;
            }
        }

    }
    
    private void CalculateDirections()
    {

        direction[0] = transform.right * range; // right direction
        direction[1] = -transform.right * range; // left direction
        /* direction[2] = transform.up * range; // up direction
         direction[3] = -transform.up * range; // down direction*/
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Manager.instance.PlayerHealth.TakeDamage(damage);
            /*Stop();*/
        }

        if (collision.tag == "Floor")
            Stop();

    }

    private void Stop()
    {
        destination = transform.position;
        attaking = false;

    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        if (deathEffect)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);

        }
        Destroy(gameObject);
    }

}
