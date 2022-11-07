using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    private float rotar = 50f;

   public GameObject contenedorArm;
    public GameObject contenedorArmB;
    public GameObject contenedorArmC;

    //public Transform contenedorArm;
    public Animator Animado;
    public bool IsArm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotar *Time.deltaTime,0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            contenedorArm.SetActive(true);
            Animado.SetBool("arma", true);
            IsArm = true;
            
            
        }
    }
}
