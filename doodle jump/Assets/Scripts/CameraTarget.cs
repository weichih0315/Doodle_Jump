using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = .3f;

    private Vector3 currentVelocity;

    public static event System.Action OnChangeHeighStatic;

    bool onEnable = true;

    Vector3 gameOverPoint;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnDeath += GameOver;
    }

    void LateUpdate () {
        if (onEnable)
        {
            if (target.position.y > transform.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                //transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
                transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed * Time.deltaTime);

                if (OnChangeHeighStatic != null)
                {
                    OnChangeHeighStatic();
                }

            }
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, gameOverPoint, ref currentVelocity, 20f * Time.deltaTime);
        }
	}

    void GameOver()
    {
        gameOverPoint = transform.position - Vector3.up * 10;
        onEnable = false;
    }
}
