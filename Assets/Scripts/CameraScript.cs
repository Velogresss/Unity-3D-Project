using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject ball;
    private Vector3 offset;
    private Vector3 mAngles;
    private float sensitivityH = 2.0f;
    private float sensitivityV = 1.0f;

    void Start()
    {
        ball = GameObject.Find("Ball");
        offset = this.transform.position - ball.transform.position;
        mAngles = this.transform.eulerAngles;
    }

    private void Update()
    {
        mAngles.y += Input.GetAxis("Mouse X") * sensitivityH;
        mAngles.x -= Input.GetAxis("Mouse Y") * sensitivityV;

        if (mAngles.x > 75f) mAngles.x = 75f;
        if (mAngles.x < 35f) mAngles.x = 35f;

        if (mAngles.y > 360) mAngles.y -= 360;
        if (mAngles.y < 0) mAngles.y += 360;
    }

    void LateUpdate()
    {
        this.transform.position = ball.transform.position + Quaternion.Euler(0, mAngles.y, 0) * offset;
        this.transform.eulerAngles = mAngles;
    }
}
