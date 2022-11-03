using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private float initTime;
    [SerializeField]
    private float repeatTime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float movimietoA;
    [SerializeField]
    private float movimietoB;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateBall", initTime, repeatTime);
      
    }
    private void Update()
    {
        TypeMove();
    }

    public void GenerateBall()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }
    public void TypeMove()
    {
        if (transform.position.z <= 27.9 || transform.position.z >= 27.9)
        {
            if (transform.position.z > movimietoA || transform.position.z < movimietoB)
            {
                speed *= -1;
            }
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}

