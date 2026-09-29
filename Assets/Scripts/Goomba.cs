using UnityEngine;

public class Goomba : EnemyBaseScript
{

    void Start()
    {
        CheckBeforeMove();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
