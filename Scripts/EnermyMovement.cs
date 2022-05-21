using UnityEngine;

public class EnermyMovement : MonoBehaviour
{
    public float speed = 4f;
    public float turnSpeed = 2f;

    public GameObject player;
    Transform monster;
    void Start()
    {
        monster = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 direction = player.transform.position - monster.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        monster.rotation = Quaternion.Slerp(monster.rotation, rotation, Time.deltaTime * turnSpeed);
        monster.Translate(0, 0, speed * Time.deltaTime);
    }
}
