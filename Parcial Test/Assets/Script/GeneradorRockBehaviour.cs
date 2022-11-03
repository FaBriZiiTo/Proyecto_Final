using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorRockBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private float initTimeRock;
    [SerializeField]
    private float repeatTimeRock;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateRock", initTimeRock, repeatTimeRock);

    }
   
    public void GenerateRock()
    {
        Instantiate(rock, transform.position, transform.rotation);
    }
 
}
