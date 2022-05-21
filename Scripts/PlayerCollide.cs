using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enermy")
        {
            GameObject enermy = other.gameObject;
            enermy.GetComponent<ObjectsAttributes>().Attack(gameObject);
        }
    }
}
