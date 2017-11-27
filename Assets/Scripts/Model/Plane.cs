using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Plane : AbstractUnit {

    public Plane(int health, float speed, float angSpeed, float acc, GameObject unitObject, Vector3 unitStartPosition, string name)
        : base (health, speed, angSpeed, acc, unitObject, unitStartPosition, name)
    {

    }

    public override void Move()
    {
        
    }

}
