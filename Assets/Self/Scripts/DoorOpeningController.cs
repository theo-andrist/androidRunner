using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningController : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationLimit = 90f;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);
            Debug.Log("!");
        }
        
    }
}
