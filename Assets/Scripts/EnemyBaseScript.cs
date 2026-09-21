using System.Reflection;
using UnityEngine;



public class EnemyBaseScript : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachThreshold = 0.05f;
    private int currentIndex = 0;
    private int direction = 1;
    private void Start()
    {
        
    }

    private void Update()
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    
}
