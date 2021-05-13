using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCoins : MonoBehaviour
{
    private float startPoxX;
    private float startPoxY;
    private bool isBeingHeld = false;

    // Update is called once per frame
    void Update()
    {
        if (this.isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPoxX, mousePos.y - startPoxY);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPoxX = mousePos.x - this.transform.localPosition.x;
            startPoxX = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
