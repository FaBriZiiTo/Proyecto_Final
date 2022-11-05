using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float speedRotate = 250;
    [SerializeField]
    private float jumpForce = 400; //jumpHeight

    private float x, z;
    public bool isSalto;  //grounded

    private float initialWalkins;
    private float walkinDown;

    public Animator Animado;
    public Rigidbody rb;//se le asigna a rigibody en el script

  

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //isSalto = false;
        initialWalkins = speed;
        walkinDown = speed * 0.5f;

    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        WalkCrouched();
        Jumping();

    }
    public void MovePlayer()
    {
        transform.Translate(0, 0, z * Time.deltaTime * speed);
        transform.Rotate(0, x * Time.deltaTime * speedRotate, 0);

        Animado.SetFloat("velX", x);
        Animado.SetFloat("velZ", z);
    }

    public void WalkCrouched()
    {

        if (Input.GetKey(KeyCode.LeftControl)) {


            Animado.SetBool("agachado", true);
            speed = walkinDown;
        }
        else
        {
            Animado.SetBool("agachado", false);
            speed = initialWalkins;

        }
        MovePlayer();
    }

    public void Jumping()
    {
       if (isSalto)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Animado.SetBool("salto", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
            Animado.SetBool("tocarSuelo",true);
        }
        else
        {
            Animado.SetBool("salto", false);
            Animado.SetBool("tocarSuelo", false);
        
        }
    }
 
}
