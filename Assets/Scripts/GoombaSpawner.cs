using UnityEngine;

public class GoombaSpawner : EnemySpawner
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject GoombaPrefab;
    public GameObject spawnPoint;
    public override EnemyBaseScript SpawnEnemy()
    {
        GameObject enemyAttack = Instantiate(GoombaPrefab, spawnPoint.transform.position, Quaternion.identity);
        return enemyAttack.GetComponent<EnemyBaseScript>();
    }
    
}
