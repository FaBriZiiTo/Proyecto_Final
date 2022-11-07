using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int vidaPlayer;
    public Slider Vida;
    public GameObject Enemy;
    public GameObject Rock;
    public GameObject Ball;
    
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("sword"))
        {
            vidaPlayer = vidaPlayer - Enemy.GetComponent<Enemy01>().damage;
           // print("Daño");
        }     

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            vidaPlayer = vidaPlayer - Rock.GetComponent<LogicaObjectosDestructores>().damage;
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            vidaPlayer = vidaPlayer - Ball.GetComponent<LogicaObjectosDestructores>().damage;
        }
    }

    public void Update()
    {
        Vida.GetComponent<Slider>().value = vidaPlayer;
        if(vidaPlayer<=0)
        {
            SceneManager.LoadScene(3);
        }
    }

}
