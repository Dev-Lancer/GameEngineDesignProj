using System.Reflection;
using UnityEngine;



public class EnemyBaseScript : MonoBehaviour
{
    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float reachThreshold = 0.05f;
    protected int currentIndex = 0;
    protected int direction = 1;
    protected void Start()
    {
        
    }

    protected void Update()
    {
       
    }
    protected void AdvanceIndex()
    {
        if (waypoints.Length == 1) return;

        currentIndex += direction;
        if (currentIndex >= waypoints.Length)
        {
            currentIndex = waypoints.Length - 2;
            direction = -1;
        }
        else if (currentIndex < 0)
        {
            currentIndex = 1;
            direction = 1;
        }
    }
     public void Move()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform wp = waypoints[currentIndex];

        if (wp == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            wp.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, wp.position) <= reachThreshold)
        {
            AdvanceIndex();
        }
    }

    public void CheckBeforeMove()
    {
        if (waypoints == null || waypoints.Length == 0)
        {

            enabled = false;
            return;
        }

        currentIndex = Mathf.Clamp(currentIndex, 0, waypoints.Length - 1);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(1);
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    
}
