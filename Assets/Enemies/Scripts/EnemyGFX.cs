using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class KenGFX : MonoBehaviour
{
    public AIPath aiPath;

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.001f) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (aiPath.desiredVelocity.x <= 0.001f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
