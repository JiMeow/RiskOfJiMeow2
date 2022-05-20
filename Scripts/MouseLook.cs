using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSenstivity = 300f;
    public Transform playerBody;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSenstivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSenstivity * Time.deltaTime;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mousex);
    }
}
