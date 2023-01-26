
using UnityEngine;

public class DoomsDay : MonoBehaviour
{
    [Header("doomsDay Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer; 
    private Vector3 destionation;   
    private bool attaking;
    private float checkTimer;
    private Vector3[] direction = new Vector3[4];


    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        //move doomsday ti destination only if attacking
        if(attaking)
            transform.Translate(destionation * Time.deltaTime * speed);
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
                destionation = direction[i];
                checkTimer = 0;
            }
        }

    }
    
    private void CalculateDirections()
    {

        direction[0] = transform.right * range; // right direction
        direction[1] = -transform.right * range; // left direction
        direction[2] = transform.up * range; // up direction
        direction[3] = -transform.up * range; // down direction
    }

    private void Stop()
    {
        destionation = transform.position;
        attaking = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Manager.instance.PlayerHealth.TakeDamage(damage);
            Stop();
        }
        


    }

}
