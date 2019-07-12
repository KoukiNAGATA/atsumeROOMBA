using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAreaGenerater : MonoBehaviour
{

    Vector3 pos;
    GameObject area;
    GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        //床を取得する
        floor = GameObject.Find("Floor");
        Vector3 floorsize = floor.GetComponent<Renderer>().bounds.size;
        // プレハブを取得
        area = (GameObject)Resources.Load("EnergyArea");
        //充電エリアを5つ用意する
        for (int i = 0; i < 5; i++)
        {
            //充電エリアを置く座標を決める
            pos = new Vector3(floor.transform.position.x + Random.Range(-floorsize.x / 2, floorsize.x / 2), floor.transform.position.x + 0.01f, floor.transform.position.z + Random.Range(-floorsize.z / 2, floorsize.z / 2));
            // プレハブからインスタンスを生成
            Instantiate(area, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
