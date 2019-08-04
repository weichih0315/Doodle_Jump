using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    public float movementSpeed = 30f;

    public float MaxX = 3.5f;
    public float MinX = -3.5f;

    float movement = 0f;

    private Rigidbody2D rigidbody2d;

    public event System.Action OnDeath;

    bool isDeath = false;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {       
        Input.gyro.enabled = true;          //設置陀螺儀功能開啟
        Input.gyro.updateInterval = 0.1f;   //陀螺儀更新頻率
    }

    private void Update()
    {
        //movement = Input.GetAxis("Horizontal") * movementSpeed;   //Test 電腦用
        movement = Input.acceleration.x * movementSpeed;

        float x = transform.position.x;     //邊界 傳送
        if (x >= MaxX)
        {
            Vector3 temp = new Vector3(MinX+0.2f, transform.position.y, transform.position.z);
            transform.position = temp;
        }
        else if (x <= MinX)
        {
            Vector3 temp = new Vector3(MaxX-0.2f, transform.position.y, transform.position.z);
            transform.position = temp;
        }

        if (transform.position.y < Camera.main.transform.position.y - 5 && !isDeath)        //調落死亡
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigidbody2d.velocity;
        velocity.x = movement;
        rigidbody2d.velocity = velocity;
    }

    private void Die()
    {
        isDeath = true;
        Debug.Log("Player Die");

        transform.localEulerAngles += Vector3.forward * 90;

        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySound2D("GameOver");

        if (OnDeath != null)
        {
            OnDeath();
        }
    }
}
