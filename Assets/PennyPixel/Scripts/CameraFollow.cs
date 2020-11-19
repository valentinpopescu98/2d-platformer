using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PennyTransform;
    public float PennyOffsetX;
    public float PennyOffsetY;

    private float mapSideLeft = -60f;
    private float mapSideRight = 179f;
    private float mapSideDown = -1.98502f;
    private float mapSideUp = 40f;

    void Update()
    {
        if (PennyTransform.position.x >= mapSideLeft && PennyTransform.position.x <= mapSideRight) 
            transform.position = new Vector3(PennyTransform.position.x + PennyOffsetX, transform.position.y, -1);
        if(PennyTransform.position.y >= mapSideDown && PennyTransform.position.y <= mapSideUp)
            transform.position = new Vector3(transform.position.x, PennyTransform.position.y + PennyOffsetY, -1);
    }
}
