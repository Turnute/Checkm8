using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("StarPulsing");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
            (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.005f, Mathf.SmoothStep(0f, 1f, i))),
            (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.005f, Mathf.SmoothStep(0f, 1f, i))),
            transform.localScale.z
            );
        }
        
    }
    private IEnumerator StarPulsing()
    {
        
        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
            (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.005f, Mathf.SmoothStep(0f, 1f, i))),
            (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.005f, Mathf.SmoothStep(0f, 1f, i))),
            transform.localScale.z
            );
            yield return new WaitForSeconds(0.015f);
        }

     
        
    }
}
