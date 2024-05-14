using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private LayerMask DoorLayer;
    [SerializeField] private LayerMask DoubleDoorLayer;
    public GameObject OpenImage;
    
    private float distance = 2;
    private RaycastHit hit;
    void Update()
    {
        if(Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, distance, DoorLayer))
        {
            OpenImage.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.gameObject.GetComponent<DoorScript>().doorisopen == false && hit.transform.gameObject.GetComponent<DoorScript>().animateable == true)
                {
                    hit.transform.gameObject.GetComponent<DoorScript>().animateable = false;
                    hit.transform.gameObject.GetComponent<Animator>().Play("opening");

                }
                if (hit.transform.gameObject.GetComponent<DoorScript>().doorisopen == true && hit.transform.gameObject.GetComponent<DoorScript>().animateable == true)
                {
                    hit.transform.gameObject.GetComponent<DoorScript>().animateable = false;
                    hit.transform.gameObject.GetComponent<Animator>().Play("closing");

                }
            }
        }
         else
         {
             OpenImage.SetActive(false);
         }
         if(Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, distance, DoubleDoorLayer))
         {
             OpenImage.SetActive(true);
             if (Input.GetKeyDown(KeyCode.E))
             {
                 if (hit.transform.gameObject.GetComponentInParent<DoorScript>().doorisopen == false && hit.transform.gameObject.GetComponentInParent<DoorScript>().animateable == true)
                 {
                     
                     hit.transform.gameObject.GetComponentInParent<DoorScript>().animateable = false;
                     hit.transform.gameObject.GetComponentInParent<Animator>().Play("DD Opening");

                 }
                 if (hit.transform.gameObject.GetComponentInParent<DoorScript>().doorisopen == true && hit.transform.gameObject.GetComponentInParent<DoorScript>().animateable == true)
                 {
                     hit.transform.gameObject.GetComponentInParent<DoorScript>().animateable = false;
                     hit.transform.gameObject.GetComponentInParent<Animator>().Play("DD Closing");

                 }
             }
         }
    }
}
