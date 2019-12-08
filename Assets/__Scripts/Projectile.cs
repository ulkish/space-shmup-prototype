using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck boundCheck;

    void Awake()
    {
        boundCheck = GetComponent<BoundsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boundCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
