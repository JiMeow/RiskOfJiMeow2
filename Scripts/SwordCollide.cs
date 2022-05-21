using UnityEngine;

public class SwordCollide : MonoBehaviour
{
    public SwordAttack swordAttack;
    public GameObject player;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enermy")
        {
            if (swordAttack.isAttack())
            {
                player.GetComponent<ObjectsAttributes>().attack(other.gameObject);
            }
        }
    }
}
