
using UnityEngine;

public class FollowingEliteEnemyBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] public float speed = 5;
    Transform player;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public int currentHealth;
    private Animator anim;

 


    private void Awake()
    {
        anim = GetComponent<Animator>();

    }


    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetTrigger("moving");

        // transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(GetRelativePos())
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
         else 
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);


    }

    private bool GetRelativePos()
    {

        float DotResult = Vector3.Dot(transform.forward, player.forward);
        if (DotResult <= 0)
        {
            return true;
        }
        return false;
    }


        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Manager.instance.PlayerHealth.TakeDamage(damage);
            GetComponent<PlayerMovement>().enabled = false;
        }



        Destroy(gameObject);
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

        Destroy(gameObject);
    }



}

