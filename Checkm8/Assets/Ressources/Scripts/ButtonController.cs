using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{/*
    public void Update(){
        if(IsMouseOver())
        {
            
        }
        else
        {
            
        }
    }

    public bool IsMouseOver()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
*/
    public void OnMouseOver(){
        Debug.Log("Mouse is over GameObject.");

        transform.localScale = new Vector3(1.01f, 1.01f, 0);
    }

    public void OnMouseExit(){
        Debug.Log("Mouse is no longer on GameObject.");
            
        transform.localScale = new Vector3(1f, 1f, 0);
    }
}
