using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray3DView : ITrayView
{

    public void Init()
    {

    }

    public void SpawnShape()
    {

    }

    public void CheckClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.Log("Mouse position: " + Input.mousePosition);

        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo, Mathf.Infinity);

        if (hitInfo.collider != null)
            Debug.Log("Hit " + hitInfo.collider.gameObject.name);
        else
            Debug.Log("No hit");
    }

}
