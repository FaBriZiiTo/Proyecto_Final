using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAgachar : MonoBehaviour
{
   public int contadorDeColision;
    

    public void OnTriggerEnter(Collider other)
    {
        contadorDeColision++;
    }

    public void OnTriggerExit(Collider other)
    {
        contadorDeColision--;
    }
}
