using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Result : MonoBehaviour
{
    [SerializeField]
    private GameObject result;
    // Start is called before the first frame update
    void Start()
    {
        GameController gc = GetComponent<GameController>();
        gc.State.Where(state => state == GameState.Init).Subscribe(state => result.SetActive(false));
        gc.State.Where(state => state == GameState.Result).Subscribe(state => result.SetActive(true));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
