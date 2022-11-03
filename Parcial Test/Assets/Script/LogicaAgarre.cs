using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAgarre : MonoBehaviour
{
    public GameObject Hand;
    private GameObject PickObject = null;

    void Update()
    {
        if (PickObject != null)//pregunta si tenemos un objeto dentro
        {
            if (Input.GetKey("q"))
            {
                PickObject.GetComponent<Rigidbody>().useGravity = true;

                PickObject.GetComponent<Rigidbody>().isKinematic = false;

                PickObject.gameObject.transform.SetParent(null);// el emparentamiento se vuelve nulo

                PickObject = null;//vuelve a la referneia nula
            }
        }

    }

    private void OnTriggerStay(Collider other)//Mientras este activado la accion
    {

        if (other.gameObject.CompareTag("ObjetoAtrapar") || other.gameObject.CompareTag("ObjetoAtraparB"))//pregunta si el otro objeto a agarrar tiene la etiqueta ObjetoAtrapar
        {
            if (Input.GetKey("e") && PickObject == null)//si presinamos la tecla "e" agarra el objeto y lo vuelve nulo la accion de agarrar otro objeto tener el objeto
            {
                other.GetComponent<Rigidbody>().useGravity = false; // se desactiva la gravedad para que al agarrar no se caiga el objeto

                other.GetComponent<Rigidbody>().isKinematic = true; // para evitar q colicione con otras cosas en el momento de agarrar

                other.transform.position = Hand.transform.position;//se pasa el objeto a al punto de las manos (Hand)

                other.gameObject.transform.SetParent(Hand.gameObject.transform);//transforma en hijo el objeto  agarrar

                PickObject = other.gameObject;//asigna una referencia del objeto ha agarrar
            }
        }
    }
}