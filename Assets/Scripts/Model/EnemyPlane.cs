using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlane : Plane {

    private NavMeshAgent agent;
    private Vector3 LastPos;

    public EnemyPlane (int health, float speed, float angSpeed, float acc, GameObject unitObject, Vector3 unitStartPosition, Vector3 lastPosition)
        : base (health, speed, angSpeed, acc, unitObject, unitStartPosition, "Enemy")
    {
        agent = UnitObject.GetComponent<NavMeshAgent>();
        agent.speed = Speed;
        agent.acceleration = acceleration;
        agent.angularSpeed = AngularSpeed;
        LastPos = lastPosition;
        UnitObject.tag = "Enemy";
    }

    public override void Move()
    {
        if (UnitObject.GetComponent<NavMeshAgent>().enabled)
        {
            if (!agent.hasPath && UnitObject.transform.position != LastPos)
            {
                agent.SetDestination(LastPos);
            }
            else if (!agent.hasPath)
            {
                agent.SetDestination(UnitStartPosition);
            }
        }
    }
}
