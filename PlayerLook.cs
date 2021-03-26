using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform player;
    public Transform head;


    public float mouseSensiticity;
    private float x = 0f;
    private float y = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = head.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        x += -Input.GetAxis("Mouse Y") * mouseSensiticity;
        y += Input.GetAxis("Mouse X") * mouseSensiticity;
        //Clamping
        x = Mathf.Clamp(x, -90, 90);
        //rotating
        transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}
