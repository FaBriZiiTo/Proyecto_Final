using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMovimiento : MonoBehaviour
{
    [SerializeField]
    private float speedFly;
    
    private bool isStop;

    // Update is called once per frame
    void Update()
    {
        ObstacleFly();
    }

    public void ObstacleFly()
    {
        if (transform.position.x > 22.39f  || transform.position.x < 14f)
        {
            speedFly *= -1;
        }
        transform.Translate(speedFly * Time.deltaTime, 0, 0);


    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);//vuelve´pariente al player al posarce sobre el objeto
        }   
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null); // transforma en nulo la asignacion de partiente en el player al salir del objeto
        }
    }
}
