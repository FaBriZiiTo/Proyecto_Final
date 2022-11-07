using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)//Mientras este activado la accion
    {
        playerController.isSalto = true;
    }
    
      
    
    private void OnTriggerExit(Collider other)//al terminar la accion
    {
        playerController.isSalto = false;
    }
}
