using System.Reflection;
using UnityEngine;

// Simple enemy that damages the player on contact.
// If the contacted root implements IDamageable, call TakeDamage.
// Falls back to destroying the player GameObject if no IDamageable is present.
public class EnemyBaseScript : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachThreshold = 0.05f;
    private int currentIndex = 0;
    private int direction = 1;
    private void Start()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogWarning($"{name}: No waypoints assigned. Enemy will not move.");
            enabled = false;
            return;
        }
        currentIndex = Mathf.Clamp(currentIndex, 0, waypoints.Length - 1);
    }

    private void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;
        var wp = waypoints[currentIndex];
        if (wp == null) return;

        transform.position = Vector2.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wp.position) <= reachThreshold)
            AdvanceIndex();
    }
    private void AdvanceIndex()
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
                damageable.TakeDamage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    
}
