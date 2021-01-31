using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focus;
    public float smooth;
    public Vector2 maxPos;
    public Vector2 minPos;

    void Start()
    {

    }

    void LateUpdate()
    {
        if(transform.position != focus.position)
        {
            Vector3 focusPos = new Vector3(focus.position.x, focus.position.y, transform.position.z);
            focusPos.x = Mathf.Clamp(focusPos.x, minPos.x, maxPos.x);
            focusPos.y = Mathf.Clamp(focusPos.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, focusPos, smooth);
        }
    }
}