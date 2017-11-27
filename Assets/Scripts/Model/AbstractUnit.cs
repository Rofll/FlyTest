using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractUnit : MonoBehaviour, IUnit {

    public int Health { get; private set; }
    public float Speed { get; private set; }
    public float AngularSpeed { get; private set; }
    protected float acceleration;
    protected GameObject UnitObject;
    protected Vector3 UnitStartPosition;

    public AbstractUnit(int health, float speed, float angSpeed, float acc, GameObject unitObject, Vector3 unitStartPosition, string name)
    {
        Health = health;
        Speed = speed;
        AngularSpeed = angSpeed;
        acceleration = acc;
        UnitObject = unitObject;
        UnitStartPosition = unitStartPosition;
        UnitObject.name = name;
        UnitObject.transform.position = UnitStartPosition;
        UnitObject.AddComponent<Hit>();
    }

    public virtual void Move()
    {

    }

    public virtual void CheckToDestroy()
    {
        if (UnitObject.transform.position.y < UnitStartPosition.y - 100)
        {
            Messenger<string>.Broadcast(GameEvent.DESTROY, UnitObject.tag);
            Destroy(UnitObject);
            Destroy(this);
        }
    }

    public virtual void Hit(int hit)
    {
        Health -= hit;
    }
}
