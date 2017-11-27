using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public float Power = 0.05f, Timer = 0.5f;
    private float shakeTimer;
    private float shakeAmount;
    private Vector3 defaultCamPos;

	void Start ()
    {
        defaultCamPos = transform.position;
    }
	

	void Update ()
    {
		if (shakeTimer > 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            float oX = transform.position.x + ShakePos.x;
            if (oX > 0.17) oX = 0.17f;
            else if (oX < -0.17f) oX = -0.17f;
            transform.position = new Vector3(oX, transform.position.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // возврат камеры и проекционного расстояния на дефолтную позицию
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5, 2f * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, defaultCamPos, 2f * Time.deltaTime);
        }
	}

    public void ShakeCamera()
    {
        shakeAmount = Power;
        shakeTimer = Timer;
        Camera.main.orthographicSize = 4.9f;
    }
}
