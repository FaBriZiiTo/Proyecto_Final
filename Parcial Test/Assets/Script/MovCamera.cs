using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamera : MonoBehaviour
{
    [SerializeField]
    private float mouseSencivity;
    [SerializeField]
    private Transform Player;
    private float rotateMouse;


    // Update is called once per frame
    void Update()
    {
        moverCam();
    }

    public void moverCam()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSencivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSencivity * Time.deltaTime;

        rotateMouse -= mouseY; //movimiento de la camara ("nota:si va en positivo el movimiento seria a la inversa")
        rotateMouse = Mathf.Clamp(rotateMouse, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotateMouse, 0f, 0f);

        Player.Rotate(Vector3.up * mouseX);//decimos que el player rote soble el el eje de vector 3
    }
}
