using UnityEngine;

public abstract class PowerUpSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract PowerUpBase SpawnPowerUp(Transform spawn);
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
