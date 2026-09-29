using UnityEngine;
using static PowerUpFactory;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EnemySpawner spawner;
    public PowerUpSpawner powerUpSpawner;
    public bool gameStart;
    public bool gameStop;
    public Transform[] JumpSpawnPoint;
    public Transform[] SpeedSpawnPoint;

    public PowerUpFactory powerUpFactory;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        GameObject[] Jumppoints = GameObject.FindGameObjectsWithTag("JumpSpawn");
        JumpSpawnPoint = new Transform[Jumppoints.Length];
        for (int i = 0; i < Jumppoints.Length; i++)
        {
            JumpSpawnPoint[i] = Jumppoints[i].transform;
        }

        GameObject[] Speedpoints = GameObject.FindGameObjectsWithTag("SpeedSpawn");
        SpeedSpawnPoint = new Transform[Speedpoints.Length];
        for (int i = 0; i < Speedpoints.Length; i++)
        {
            SpeedSpawnPoint[i] = Speedpoints[i].transform;
        }



    }

    public void StartGame()
    {
        gameStart = true;
        gameStop = false;
    }

    public void EndGame()
    {
        gameStop = true;
        gameStart = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log("GameManager Start");
        //EnemyBaseScript enemy = spawner.SpawnEnemy();

        for (int i = 0; i < JumpSpawnPoint.Length; i++)
        {
            Debug.Log("Spawning Jump at " + JumpSpawnPoint[i].position);
            powerUpFactory.SpawnPowerUp(PowerUpFactory.PowerUpType.Jump,JumpSpawnPoint[i]);
        }

        // Spawn Speed Power-Ups at every fixed speed spawn point
        for (int i = 0; i < SpeedSpawnPoint.Length; i++)
        {
            Debug.Log("Spawning Speed at " + SpeedSpawnPoint[i].position);
            powerUpFactory.SpawnPowerUp( PowerUpFactory.PowerUpType.Speed,SpeedSpawnPoint[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
