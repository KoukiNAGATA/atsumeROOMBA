using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    public GameObject player;//カメラを基準に移動させる
    public float horizontalInput;//横矢印キー
    private Vector3 ROOMBAPos;//ルンバの座標

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("ROOMBA");
        ROOMBAPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // ROOMBAの移動量分、カメラも移動する
        transform.position += player.transform.position - ROOMBAPos;
        ROOMBAPos = player.transform.position;

        // ルンバの位置のY軸を中心に、カメラを回転（公転）させる
        transform.RotateAround(ROOMBAPos, Vector3.up, horizontalInput * Time.deltaTime * 200f);
    }
}
