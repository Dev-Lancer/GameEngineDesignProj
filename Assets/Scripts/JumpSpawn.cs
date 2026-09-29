using UnityEngine;

public class JumpSpawn : PowerUpSpawner
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject JumpPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        
    }
    public override PowerUpBase SpawnPowerUp(Transform spawn)
    {
     
        GameObject jumpBoost = Instantiate(JumpPrefab, spawn.transform.position, Quaternion.identity);
        return jumpBoost.GetComponent<PowerUpBase>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
