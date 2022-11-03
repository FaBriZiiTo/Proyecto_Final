using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonControll : MonoBehaviour
{
    private GameObject Terra;
    private GameObject compuerta;
    private GameObject TerraB;

    private void Start()
    {
        Terra = GameObject.Find("GlobeTerra1");
        TerraB = GameObject.Find("GlobeTerra3");
        compuerta = GameObject.Find("CompuertaFinal");

    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.tag =="ObjetoAtrapar")
        {
            Destroy(GameObject.Find("Compuerta"));
            Destroy(Terra);
        }
        
        if (other.tag =="ObjetoAtraparB")
        {
            Destroy(compuerta);
            
        }
    }

}
