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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ruin")
        {
            GameObject Ruin = other.gameObject;
            gameObject.GetComponent<PlayerInteract>().Interact(Ruin);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ruin")
        {
            GameObject Ruin = other.gameObject;
            gameObject.GetComponent<PlayerInteract>().NotInteract(Ruin);
        }
    }
}
