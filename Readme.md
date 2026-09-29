Name: Nhat Minh Duong
Student Number: 100971208

Project Description: 2D Platform
This is a 2D platform game where the player moves around the map, jumps across platforms to collect powerups, avoid the enemy , and get to the final goal
Gameplay Loop: 
Move and Jump around the level.
Avoid the enemies.
Collect power ups.
Power ups increase player's speed and jump power.
Continue through the level while managing enemies and obstacles.

The design Pattern I used was Factory Pattern for the game power ups system. The PowerUpFactory script is responsible for creating different types of power-ups. Instead of the GameManager directly creating JumpPowerUp or SpeedPowerUp objects, it requests the required type from the factory.
Diagram:
GameManager --> PowerUpFactory : requests power-up
PowerUpFactory --> PowerUpBase : creates 
PowerUpBase <-- JumpPowerUp 
PowerUpBase <-- SpeedPowerUp
GameManager --> JumpSpawnPoint : provides position 
GameManager --> SpeedSpawnPoint : provides position
class PowerUpFactory { SpawnPowerUp(type, spawnPoint) }
class PowerUpBase {ApplyPowerUp(PlayerMovement)}
class JumpPowerUp {ApplyPowerUp(PlayerMovement)} 
class SpeedPowerUp {ApplyPowerUp(PlayerMovement)}

The gameManager contain all the spawn point data, when the game start it will run 2 different loops for each power ups(I set cretain spawn points for each power ups) and it will send power up type and spawn location to PowerUpFactory
The factory determines which prefab should be created and instantiates it at the provided spawn point.
GameManager ---->  PowerUpFactory  ---- Jump ----> JumpPowerUp ---- Speed ---> SpeedPowerUp

What element of your game adopts the chosen pattern?
The power up spawning system which I applied the factory pattern can create different power up objects, including JumpPowerUp and SpeedPowerUp.
Both power-ups inherit from PowerUpBase, allowing them to share a common structure while having different effects on the player.
Why is this pattern a good choice for the associated functionality?
The factory pattern is super useful for powerup system because you dont have to create a bunch of script that only serve as power ups.
Instead of having the GameManager directly instantiate every type of power-up, it can request a power-up from the factory, it will make the system easier to expand if you want to add more type of power ups to debuff power up.

build file drive: https://drive.google.com/drive/folders/1lbLhpNByZigigguvZn4G13Ddm9wZTjBs?usp=sharing 



