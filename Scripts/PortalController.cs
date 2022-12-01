using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform target;
    public Transform player;

    private CharacterController cController;

    void Start()
    {
        cController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cController.enabled = false;
            player.forward = target.forward;

            player.position = target.position + target.forward;
            cController.enabled = true;
        }
    }
   
    void Update()
    {
        
    }
}
