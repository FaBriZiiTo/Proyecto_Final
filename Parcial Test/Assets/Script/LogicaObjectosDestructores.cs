using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaObjectosDestructores : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public int damage;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {

       transform.Translate(speed * Time.deltaTime, 0, 0);

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
           // SceneManager.LoadScene(3);           
        }

        if (collision.gameObject.CompareTag("paredDestructora"))
        {
            Destroy(gameObject);
        }
    }   
}
