using UnityEngine;

public class SpeedSpawn : PowerUpSpawner
{
    public GameObject SpeedPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        
    }
    public override PowerUpBase SpawnPowerUp(Transform spawn)
    {
        GameObject speedBoost = Instantiate(SpeedPrefab, spawn.transform.position, Quaternion.identity);
        return speedBoost.GetComponent<PowerUpBase>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
