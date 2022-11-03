using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLaser : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float limitedPositive;
    [SerializeField]
    private float limitedNegative;
    [SerializeField]
    private float limitedPositiveB;
    [SerializeField]
    private int direction;


    // Start is called before the first frame update
    void Update()
    {
        MoveLaser();
    }
    public void MoveLaser()
    {
        switch (direction)
        {
            case 1:
                {
                    if (transform.position.z > limitedPositive || transform.position.z < limitedPositiveB || transform.position.z < -limitedNegative)
                    {
                        speed *= -1;
                    }
                    transform.Translate(0, 0, speed*Time.deltaTime);

                    break;
                }

            case 2:
                {
                    if (transform.position.x > limitedPositive || transform.position.x < -limitedNegative)
                    {
                        speed *= -1;
                    }
                    transform.Translate(0, 0, -speed*Time.deltaTime);
                    break;
                }
        }

    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(other.gameObject);
        }
    }

   /* public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }
    }*/

}
