using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnMonster : MonoBehaviour
{
    //randomly spawn enermy
    public GameObject player;
    public ObjectsAttributes playersAttributes;
    public GameObject enermy;
    float spawnTime = 3f;
    float lastTimeSpawn = 0f;
    float startSceneTime;
    int sceneIndex;
    bool bossSpawned = false;

    void Start()
    {
        startSceneTime = Time.time;
        playersAttributes = player.GetComponent<ObjectsAttributes>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Time.time - startSceneTime - lastTimeSpawn > spawnTime)
        {
            lastTimeSpawn = Time.time;
            if (playersAttributes.GetKillCount() > 15 * (sceneIndex + 1))
            {
                Spawn();
            }
            else if (!bossSpawned)
            {
                Debug.Log("Something went wrong?");
                Debug.Log("Something went wrong?");
                Debug.Log("Something went wrong?");
                bossSpawned = true;
                Invoke("SpawnBoss", 5f);
            }
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

    void SpawnBoss()
    {
        GameObject monster = enermy.transform.GetChild(2).gameObject;
        monster = Instantiate(monster, player.transform.position + new Vector3(0, 10, 0), player.transform.rotation);
        monster.transform.localScale = new Vector3(4, 4, 4);
    }
}
