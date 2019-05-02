using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObj : MonoBehaviour
{
    public Transform obj;
    public float radius = 3f; //interact radius of object

    private bool isFocused = false; // check if obj is in players focus
    private bool wasUsed = false; // check if object waw already used

    private Transform player;

    // meaned to be used  for overriding from dif objects
    public virtual void Interaction()
    {
        Debug.Log("Interact with " + transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFocused)
        { 
            float distance = Vector3.Distance(player.position, obj.position);
            if (distance <= radius)
            {
                Interaction();
                wasUsed = true;
            }
        }
    }

    //
    public void onFocused(Transform playerObj)
    {
        isFocused = true;
        player = playerObj;
        wasUsed = true;
    }

    public void onDefocused()
    {
        isFocused = false;
        player = null;
        wasUsed = false;
    }
    
    // show radious of interaction with object
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(obj.position, radius);
    }
}
