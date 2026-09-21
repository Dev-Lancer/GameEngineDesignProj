using UnityEngine;

public class Goomba : EnemyBaseScript
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachThreshold = 0.05f;
    private int currentIndex = 0;
    private int direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogWarning($"{name}: No waypoints assigned. Enemy will not move.");
            enabled = false;
            return;
        }
        currentIndex = Mathf.Clamp(currentIndex, 0, waypoints.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;
        var wp = waypoints[currentIndex];
        if (wp == null) return;

        transform.position = Vector2.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wp.position) <= reachThreshold)
            AdvanceIndex();
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
}
