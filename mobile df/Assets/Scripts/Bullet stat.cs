using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletstat
{
    public float speed { get; set; }
    public int damage { get; set; }

    public Bulletstat(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }


}
