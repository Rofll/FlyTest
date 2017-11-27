using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Config _config;

    private PlayerPlane _player;
    private EnemyPlane _enemy;
    private Dictionary<string, AbstractUnit> units;

    // Use this for initialization
    void Start()
    {
        units = new Dictionary<string, AbstractUnit>();
        units.Add("Player", new PlayerPlane(_config.PlayerHealth, _config.PlayerMaxSpeed, _config.PlayerAngularSpeed, _config.PlayerAcceleration, Instantiate(_config.Plane), _config.PlayerStartPosition));
        units.Add("Enemy", new EnemyPlane(_config.EnemyHealth, _config.EnemyMaxSpeed, _config.EnemyAngularSpeed, _config.EnemyAcceleration, Instantiate(_config.Plane), new Vector3(3f, 4.516667f, -1.5f), new Vector3(-1, 4.516667f, -7.4f)));
        Messenger<string>.AddListener(GameEvent.DESTROY, RemoveList);
    }

	// Update is called once per frame
	void Update ()
    {
        foreach (KeyValuePair<string, AbstractUnit> item in units)
        {
            item.Value.Move();
            item.Value.CheckToDestroy();
        }
	}

    void RemoveList(string a)
    {
        units.Remove(a);
    }
}
