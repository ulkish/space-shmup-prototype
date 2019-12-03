using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    // The speed in m/s.
    public float speed = 10f;
    // Seconds/shot (Unused).
    public float fireRate = 0.3f;
    public float health = 10;
    // Points earned for detroying this.
    public int score = 100;
    private BoundsCheck boundsCheck;

    void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
    }

    // Property: A method that acts like a field.
    public Vector3 pos
    {
        get
        {
            return(this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        Move();

        if (boundsCheck != null && !boundsCheck.isOnScreen)
        {
            // Check to make sure it's gone off the bottom of the screen.
            if (pos.y < boundsCheck.camHeight - boundsCheck.radius)
            {
                // We're off the bottom, so destroy this GameObject.
                Destroy(gameObject);
            }
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
