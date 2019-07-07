using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ROOMBAMover : MonoBehaviour
{
    public Rigidbody rb;
    private bool _pushed;//スペースキーが押されているかの判定
    public const float MAX = 15.0f;
    float power = MAX;//ルンバのMAX充電時走行可能時間
    Slider _gauge;//充電ゲージ

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _gauge = GameObject.Find("PowerGauge").GetComponent<Slider>();
        //スタートまで3秒止める
        StartCoroutine("WaitForStart");
    }

    private IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(3.0f);
    }

    private IEnumerator NoPower()
    {
        _pushed = false;
        yield return new WaitForSeconds(5.0f);
        power = MAX;
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

        // 毎フレーム毎に充電を減らしていく
        power -= Time.deltaTime;
        if (power <= 0)//充電がなくなったら5秒止める
        {
            // コルーチンを実行  
            StartCoroutine("NoPower");
        }
        // 充電ゲージに値を設定
        _gauge.value = power;
    }

    void OnTriggerStay(Collider col)//充電エリアとの当たり判定
    {
        //衝突したオブジェクトがEnergyAreaだった場合
        if(power >= MAX){
        }
        else if (col.gameObject.tag == "EnergyArea")
        {
            power += Time.deltaTime * 4;
        }
        _gauge.value = power;
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
