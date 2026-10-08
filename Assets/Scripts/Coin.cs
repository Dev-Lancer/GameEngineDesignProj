using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collect()
    {
        GameManage.Instance.AddScore(10);
        Destroy(gameObject);
    }
}