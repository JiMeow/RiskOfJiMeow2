using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject InteractButton;
    public void Interact(GameObject gameObject)
    {
        InteractButton.SetActive(true);
        if (gameObject.tag == "Ruin" && Input.GetKey(KeyCode.E))
        {
            gameObject.GetComponent<Ruin>().Activate();
        }
    }
    public void NotInteract(GameObject gameObject)
    {
        InteractButton.SetActive(false);
    }
}
