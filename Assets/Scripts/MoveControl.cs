using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private InteractObj focusTarget; // chosen one target to focus on
    private Camera camera; // ref to main camera
    private Move_3p motor; // ref to player agent
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        motor = GetComponent<Move_3p>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("move to point " + hit.collider.name + " " + hit.point);
                motor.MoveTo(hit.point);
                noFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                InteractObj interactable = hit.collider.GetComponent<InteractObj>();
                if (interactable != null)
                {
                    Focus(interactable);
                }
            }
        }
    }
    
    //used if move to target
    void Focus(InteractObj NewFocusObj)
    {
        if (NewFocusObj != focusTarget)
        {
            if (focusTarget != null)
            {
                focusTarget.onDefocused();
            }
            motor.FollowTarget(NewFocusObj);
            focusTarget = NewFocusObj;
        }
    }
    
    //used if move to point
    void noFocus()
    {
        if (focusTarget != null)
        {
            focusTarget.onDefocused();
        }
        focusTarget = null;
        motor.StopFollow();
    }
}
