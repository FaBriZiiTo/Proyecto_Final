using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaObjectosDestructores : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {

       transform.Translate(speed * Time.deltaTime, 0, 0);

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("paredDestructora"))
        {
            Destroy(gameObject);
        }
    }
}
