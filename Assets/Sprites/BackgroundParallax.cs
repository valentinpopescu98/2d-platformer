using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public Sprite spriteGrass;
    public Sprite spriteJungle;
    public Transform PennyTransform;

    public GameObject camera;
    private float lengthX, startPosX, startPosY;
    public float parallaxSpeed;

    void Start()
    {
        startPosX = transform.position.x + 55.25f;
        startPosY = transform.position.y + 1;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (PennyTransform.position.x < 65)
            GetComponent<SpriteRenderer>().sprite = spriteGrass;
        else
            GetComponent<SpriteRenderer>().sprite = spriteJungle;

        float temp = (camera.transform.position.x * (1 - parallaxSpeed));
        float distanceX = (camera.transform.position.x * parallaxSpeed);
        float distanceY = (camera.transform.position.y * parallaxSpeed);

        transform.position = new Vector3(startPosX + distanceX, startPosY + distanceY, transform.position.z);

        if (temp > startPosX + lengthX)
            startPosX += lengthX;
        else if (temp < startPosX - lengthX)
            startPosX -= lengthX;
    }
}
