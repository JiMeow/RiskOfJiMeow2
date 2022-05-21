using UnityEngine;

public class SwordCollide : MonoBehaviour
{
    public SwordAttack swordAttack;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enermy")
        {
            if (swordAttack.isAttack())
            {
                Destroy(other.gameObject);
            }
        }
    }
}
