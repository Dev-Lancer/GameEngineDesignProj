using UnityEngine;

public class PowerUpFactory : MonoBehaviour
{
    public enum PowerUpType
    {
        Jump,
        Speed
    }
    [SerializeField] private JumpSpawn jumpSpawner;
    [SerializeField] private SpeedSpawn speedSpawner;

    public PowerUpBase SpawnPowerUp(PowerUpType type, Transform spawnPoint)
    {
        if (type == PowerUpType.Jump)
        {
            return jumpSpawner.SpawnPowerUp(spawnPoint);
        }
        if (type == PowerUpType.Speed)
        {
            return speedSpawner.SpawnPowerUp(spawnPoint);
        }
        return null;
    }
}