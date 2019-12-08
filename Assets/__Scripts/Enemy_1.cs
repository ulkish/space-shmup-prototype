﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    [Header("Set in Inspector: Enemy_1")]
    // Number of seconds for a full sine wave.
    public float waveFrequency = 2;
    // Sine wave width in meters.
    public float waveWidth = 4;
    public float waveRotY = 45;
    // The initial x value of pos.
    private float x0;
    private float birthTime;

    // Start works well because it's not used by the Enemy superclass.
    void Start()
    {
        // Set x0 to the initial x position of Enemy_1
        x0 = pos.x;

        birthTime = Time.time;
    }

    // Override the Move function on Enemy.
    public override void Move()
    {
        // Because pos is a property, you can't directly set pos.x
        // so get the pos as an editable Vector3.
        Vector3 tempPos = pos;
        // Theta adjusts based on time.
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        // Rotate a bit about Y.
        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);

        // base.Move() still handles the movement down in y.
        base.Move();
        // print( bndCheck.isOnScreen );
    }

}
