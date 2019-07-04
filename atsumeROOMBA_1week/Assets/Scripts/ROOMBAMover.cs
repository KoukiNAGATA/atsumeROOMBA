using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROOMBAMover : MonoBehaviour
{
    public Rigidbody rb;
    private bool _pushed;//スペースキーが押されているかの判定

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pushed = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _pushed = false;
        }
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * 7;

        if (_pushed)
        {
            rb.AddForce(moveForward);
        }
    }
}
