using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPlane : Plane {

    private NavMeshAgent agent;

    public PlayerPlane(int health, float speed, float angSpeed, float acc, GameObject unitObject, Vector3 unitStartPosition)
        : base (health, speed, angSpeed, acc, unitObject, unitStartPosition, "Player")
    {
        agent = UnitObject.GetComponent<NavMeshAgent>();
        agent.speed = Speed;
        agent.acceleration = acceleration;
        agent.angularSpeed = AngularSpeed;
        UnitObject.tag = "Player";
    }

    public override void Move()
    {
        if (UnitObject.GetComponent<NavMeshAgent>().enabled)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    agent.SetDestination(hit.point);
                }
            }
#else
            if (Input.touchCount == 1)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                switch (Input.GetTouch(0).phase)
                {
                    case (TouchPhase.Began):
                        if (Physics.Raycast(ray, out hit, 100))
                        {
                            agent.SetDestination(hit.point);
                        }
                        break;

                    case (TouchPhase.Moved):
                         if (Physics.Raycast(ray, out hit, 100))
                        {
                            agent.SetDestination(hit.point);
                        }
                        break;

                    case (TouchPhase.Ended):
                         if (Physics.Raycast(ray, out hit, 100))
                        {
                            agent.SetDestination(hit.point);
                        }
                        break;

                }
            }
#endif

        }
    }

}
