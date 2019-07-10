using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float radius = 1.5f;

	void Update ()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hitCollider in hitColliders)
            {
                Vector3 direction = hitCollider.transform.position - transform.position;
                //dot function: direction foward of the player vs direction of player to the object (direction)
                //if closer to 1 mean its more of the same direction
                if (Vector3.Dot(transform.forward, direction) > .5f)     
                {
                    hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                }               
            }
        }	
	}
}
