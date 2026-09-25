using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EnemySpawner spawner;
    public bool gameStart;
    public bool gameStop;

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
    void Start()
    {
        EnemyBaseScript enemy = spawner.SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
