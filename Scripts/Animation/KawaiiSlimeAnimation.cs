using UnityEngine;
// using UnityEngine.Animator;
public class KawaiiSlimeAnimation : MonoBehaviour
{
    Animator animator;
    private float animationdelay = 1.5f;
    private float lastAttackTime;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Random.Range(0, 2) == 0 && Time.time - lastAttackTime > animationdelay)
        {
            animator.SetTrigger("Jump");
            lastAttackTime = Time.time;
        }
    }
    void AlertObservers(string message)
    {
        // Notify all observers
        // Debug.Log(message);
    }
}
