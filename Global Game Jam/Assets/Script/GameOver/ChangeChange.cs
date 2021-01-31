using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool ispressed = false;

    void Update()
    {
        if (ispressed)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
