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
    private float jumpForce = 5f;

    private float x, z;
    public bool isSalto;


    private float initialWalkins;
    private float walkinDown;
    private float walkinPickUp;
    private float SprintRun;
    private float jumpSprint;

    public Animator Animado;
    public Rigidbody rb;//se le asigna a rigibody en el script

    //cambio de colicion para agacharse y pararce
    [SerializeField]
    private CapsuleCollider Parado;
    [SerializeField]
    private CapsuleCollider Agachado;
    [SerializeField]
    private CapsuleCollider echado; 

    public LogicaAgachar logicaAgachar;
    public GameObject ParteSuperiorCorona;
    private void Start()
    {
        isSalto = false;
        jumpSprint = jumpForce*0.3f;
        initialWalkins = speed;
        walkinDown = speed * 0.5f;
        walkinPickUp = speed * 0.7f;
        SprintRun = speed * 1.5f;
        
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        MovePlayer();
    }
    public void MovePlayer()
    {
        transform.Translate(0, 0, z * Time.deltaTime * speed);
        transform.Rotate(0, x * Time.deltaTime * speedRotate, 0);

        Animado.SetFloat("velX", x);
        Animado.SetFloat("velZ", z);
        
        WalkCrouched();
        Jumping();
        Sprint();
    }

   public void WalkCrouched()
    {
     
        if (Input.GetKey(KeyCode.LeftControl)) {


            Animado.SetBool("agachado", true);
            speed = walkinDown;

            //cambio de collider
            Agachado.enabled = true;//collider activado verdadero
            Parado.enabled = false;//collider activado falso

            ParteSuperiorCorona.SetActive(true);
        }
        else
        {
         //si el contador de logica agachar es igual o menor a 0 no hay un objeto arriba por lo tanto accede a pararse
            if (logicaAgachar.contadorDeColision <= 0)
            {
                Animado.SetBool("agachado", false);
                speed = initialWalkins;

                //cambio de collider

                Agachado.enabled = false;//collider activado false
                Parado.enabled = true;//collider activado verdadero

                ParteSuperiorCorona.SetActive(false);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
                Animado.SetBool("giro", true);
           
        }
        else
        {
            Animado.SetBool("giro", false);
     
        }
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
            Animado.SetBool("tocarSuelo", true);
        }
        else
        {
            Animado.SetBool("salto", false);
            Animado.SetBool("tocarSuelo", false);

        }
    }
    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            Animado.SetBool("Sprint",true);
            speed = SprintRun;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSprint, 0), ForceMode.Impulse);
            }
        }
        else
        {
            Animado.SetBool("Sprint", false);
            speed = initialWalkins;
        }
        if (Input.GetKey(KeyCode.F))
        {
            
            Animado.SetBool("deslizar", true);

            echado.enabled = true;
            if (echado)
            {
                Parado.enabled = false;
                ParteSuperiorCorona.SetActive(true);
                Animado.SetBool("cuclillas", true);
            }
            
        }
        else
        {
            if (logicaAgachar.contadorDeColision <= 0)
            {
                Animado.SetBool("deslizar", false);
                
                echado.enabled = false;
                if (!echado)
                {
                    Agachado.enabled = true;
                    ParteSuperiorCorona.SetActive(false);
                    
                }

            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Animado.SetBool("cuclillas", false);
            }
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ObjetoAtrapar") || other.gameObject.CompareTag("ObjetoAtraparB"))
        {
            if (Input.GetKeyDown("e"))
            {
                Animado.SetBool("agarrar", true);
                speed = walkinPickUp;
            }
            else if (Input.GetKeyDown("q"))
            {
                Animado.SetBool("agarrar", false);
                speed = initialWalkins;
            }
        }
    }
}
