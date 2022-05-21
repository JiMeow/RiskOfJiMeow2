using UnityEngine;
// using UnityEngine.Animator;
public class KawaiiSlimeAnimation : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetTrigger("Attack");
    }
    void AlertObservers(string message)
    {
        // Notify all observers
        Debug.Log(message);
    }
}
