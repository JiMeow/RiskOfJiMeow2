using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    //randomly spawn enermy
    public GameObject player;
    public GameObject enermy;
    float spawnTime = 3f;
    float lastTimeSpawn = 0f;
    float startSceneTime;

    void Start()
    {
        startSceneTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startSceneTime - lastTimeSpawn > spawnTime)
        {
            lastTimeSpawn = Time.time;
            Spawn();
        }
    }

    void Spawn()
    {
        //randomly spawn enermy
        int difcorx = Random.Range(-30, 30);
        if (difcorx > 0) difcorx += 10;
        else difcorx -= 10;

        int difcorz = Random.Range(-30, 30);
        if (difcorz > 0) difcorz += 10;
        else difcorz -= 10;

        int id = Random.Range(0, 2);
        GameObject monster = enermy.transform.GetChild(id).gameObject;

        Instantiate(monster, player.transform.position + new Vector3(difcorx, 10, difcorz), player.transform.rotation);
    }
}
