using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countdownLabel;

    // Start is called before the first frame update
    void Start()
    {
        GameController gc = GetComponent<GameController>();
        gc.Count.Subscribe(x => Debug.Log(x));
        gc.State.Subscribe(x => Debug.Log(x));
    }

    void Countdown(int count)
    {
        countdownLabel.text = count > 0 ? count.ToString() : "Go";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
