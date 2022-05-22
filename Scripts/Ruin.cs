using UnityEngine;

public class Ruin : MonoBehaviour
{
    public SpawnMonster spawnMonster;
    public void Activate()
    {
        spawnMonster.SpawnBoss();
    }
}
