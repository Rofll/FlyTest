using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hit : MonoBehaviour {

    GameObject go;

    public void OnCollisionEnter(Collision collision)
    {
        if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
        {
            go = new GameObject();
            go.name = gameObject.name;
            Messenger<string>.AddListener(GameEvent.DESTROY, DestoySemiParent);
            Vector3 force = gameObject.GetComponent<NavMeshAgent>().velocity * 10;
            Vector3 force2 = collision.gameObject.GetComponent<NavMeshAgent>().velocity;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Rigidbody>().AddForce(force);
            Camera.main.gameObject.GetComponent<CameraShaker>().ShakeCamera();

            while (transform.Find("Root_Flyer").transform.Find("Root_Machine").childCount != 0)
            {
                transform.Find("Root_Flyer").transform.Find("Root_Machine").GetChild(0).gameObject.AddComponent<Rigidbody>();
                transform.Find("Root_Flyer").transform.Find("Root_Machine").GetChild(0).gameObject.AddComponent<ChildrenDestroy>();
                transform.Find("Root_Flyer").transform.Find("Root_Machine").GetChild(0).gameObject.AddComponent<BoxCollider>();
                transform.Find("Root_Flyer").transform.Find("Root_Machine").GetChild(0).gameObject.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
                transform.Find("Root_Flyer").transform.Find("Root_Machine").GetChild(0).parent = go.transform;
            }
        }
    }

    public void DestoySemiParent(string name)
    {
        if (go.name == name)
        {
            Destroy(go);
        }
    }
}
