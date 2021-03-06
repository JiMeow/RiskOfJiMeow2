using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private float recoil = 0.30f;
    private float maxRecoil_x = -20f;
    private float maxRecoil_y = 20f;
    private float recoilSpeed = 4f;

    private float lastAttackTime;
    private float attackDelay = 0.5f;
    Quaternion originRotation;
    void Start()
    {
        originRotation = transform.localRotation;
    }
    public void StartRecoil(float recoilParam, float maxRecoil_xParam, float recoilSpeedParam)
    {
        // in seconds
        recoil = recoilParam;
        maxRecoil_x = maxRecoil_xParam;
        recoilSpeed = recoilSpeedParam;
        maxRecoil_y = Random.Range(-maxRecoil_xParam, maxRecoil_xParam);
    }
    void recoiling()
    {
        if (recoil > 0f)
        {
            Quaternion maxRecoil = Quaternion.Euler(0, maxRecoil_y, -50f);
            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp(transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed);
            recoil -= Time.deltaTime;
        }
        else
        {
            recoil = 0;
            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp(transform.localRotation, originRotation, Time.deltaTime * recoilSpeed);
            if (transform.localRotation == originRotation)
            {
                recoil = 0.30f;
            }
        }
    }
    public bool isAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && recoil > 0f && recoil != 0.30f)
        {
            if (Time.time - lastAttackTime > attackDelay)
            {
                lastAttackTime = Time.time;
                return true;
            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // StartRecoil(0.1f, -20f, 2f);
            recoiling();
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, originRotation, Time.deltaTime * recoilSpeed);
            if (transform.localRotation == originRotation)
            {
                recoil = 0.30f;
            }
        }
    }
}