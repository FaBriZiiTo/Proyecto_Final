using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    private GameObject terraB;
    [SerializeField]
    private GameObject Player;

    private void Start()
    {
        //isPlaced = true;
        Player = GameObject.FindGameObjectWithTag("Player");
        terraB = GameObject.Find("GlobeTerra2");
    }
    void Update()
    {
    }
    public void OnTriggerEnter(Collider other)
    {

        if (CompareTag("portal1"))
        {
            Player.transform.position = new Vector3(38.11f, 0.042f, 53.57f);
        }



        if (CompareTag("portal2"))
        {
            if (other.tag == "ObjetoAtrapar")
            {
                Player.transform.position = new Vector3(45.03f, 2.13f, 48.08f);
                Destroy(terraB);
            }
           
         }
        if (CompareTag("portal3"))
        {
            Player.transform.position = new Vector3(36.879f, 0.135f, 45.316f);
        }
        if (CompareTag("portalPiso"))
        {
            Player.transform.position = new Vector3(45.03f, 2.13f, 48.08f);
        }
    }
}

/*public void OnTriggerEnter(Collider other)
{

    if (CompareTag("Portal1"))
    {
        other.transform.position = new Vector3(38.11f, 0.042f, 53.57f);
    }
    if (CompareTag("Portal2"))
    {
        other.transform.position = new Vector3(36.879f, 0.135f, 45.316f);
    }
    if (CompareTag("Portal3"))
    {
        other.transform.position = new Vector3(36.879f, 0.135f, 45.316f);
    }

}*/