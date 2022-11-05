using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator ani;
    public Enemy01 enemigo;

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
        enemigo.atacando = true;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
