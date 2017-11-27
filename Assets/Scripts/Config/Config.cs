using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create GameConfig")]
public class Config : ScriptableObject {

    public GameObject Plane;
    public int PlayerHealth;
    public int EnemyHealth;
    public float PlayerMaxSpeed;
    public float EnemyMaxSpeed;
    public float PlayerAcceleration;
    public float EnemyAcceleration;
    public float PlayerAngularSpeed;
    public float EnemyAngularSpeed;
    public float Gravity;
    public Vector3 PlayerStartPosition;
}
