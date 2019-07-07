using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrashScript : MonoBehaviour
{
    public GameObject Bottle1_2;
    public GameObject Cerial_2;
    public GameObject Desks;
    public int NumofBottles = 20;
    public int NumofBoxes = 10;
    public int NumofDesks = 5;
    public AudioClip audio;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < NumofBottles; i++)
        {
            // インスタンス生成
            GameObject bottle = Instantiate(Bottle1_2) as GameObject;
            // ランダムな場所に配置
            bottle.transform.position = new Vector3(Random.Range(-45, 45), 1, Random.Range(-45, 45));
            bottle.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 359), 0);
        }

        for (int i = 0; i < NumofBoxes; i++)
        {
            // インスタンス生成
            GameObject box = Instantiate(Cerial_2) as GameObject;
            // ランダムな場所に配置
            box.transform.position = new Vector3(Random.Range(-45, 45), 1, Random.Range(-45, 45));
            box.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 359), 0);
        }

        for (int i = 0; i < NumofDesks; i++)
        {
            // インスタンス生成
            GameObject desk = Instantiate(Desks) as GameObject;
            // ランダムな場所に配置
            desk.transform.position = new Vector3(Random.Range(-45, 45), 1, Random.Range(-45, 45));
            desk.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 359), 0);
        }

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audio;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
