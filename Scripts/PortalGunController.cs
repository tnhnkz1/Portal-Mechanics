using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunController : MonoBehaviour
{
    public GameObject bluePortal, orangePortal;
    private Camera cam;
    private RaycastHit hit;

    private Vector3 blueRot;
    private Vector3 orangeRot;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SendRay())
            {
                OpenBluePortal();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (SendRay())
            {
                OpenOrangePortal();
            }
        }    
    }

    private void OpenBluePortal()
    {
        bluePortal.transform.position = hit.point;
        bluePortal.transform.forward = hit.transform.forward;
        bluePortal.SetActive(true);
    }

    private void OpenOrangePortal()
    {
        orangePortal.transform.position = hit.point;
        orangePortal.transform.forward = hit.transform.forward;
        orangePortal.SetActive(true);
    }

    public bool SendRay()
    {
        if (Physics.Raycast(cam.gameObject.transform.position, cam.gameObject.transform.forward, out hit, 100))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true;
            }
        }

        return false;
    }
}
