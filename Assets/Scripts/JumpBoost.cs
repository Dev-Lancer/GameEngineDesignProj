using UnityEngine;

public class JumpBoost : PowerUpBase
{
    public override void ApplyPowerUp(PlayerMovement player)
    {
        player.jumpPow += jumpIncrease;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
