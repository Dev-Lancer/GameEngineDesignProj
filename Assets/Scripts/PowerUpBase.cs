using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    

    public abstract void ApplyPowerUp(PlayerMovement player);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                ApplyPowerUp(player);
                Destroy(gameObject);
            }
        }
    }
}
