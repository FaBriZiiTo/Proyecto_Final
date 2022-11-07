using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaArma : MonoBehaviour
{
    [SerializeField]
    private Transform PosicionDisparo;
    private float laserRange = 100f;
    private float laserDuration = 0.06f;

    private Camera Cam;
    private LineRenderer lineRenderer;

    private void Start()
    {
        Cam = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Disparo();

    }
    IEnumerator RenderLine()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        lineRenderer.enabled = false;
    }
    public void Disparo()
    {
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            Vector3 rayOrigin = Cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Ray ray = new Ray(rayOrigin, Cam.transform.forward);

            lineRenderer.SetPosition(0, PosicionDisparo.position);


            if (Physics.Raycast(ray, out hit))
            {
                lineRenderer.SetPosition(1, hit.point);

                if (hit.collider.gameObject.CompareTag("Enemigo"))
                {
                    Destroy(hit.transform.gameObject);
                }

            }
            else
            {
                lineRenderer.SetPosition(1, PosicionDisparo.position + Cam.transform.forward * laserRange);
            }
            StartCoroutine(RenderLine());
        }
    }
}
