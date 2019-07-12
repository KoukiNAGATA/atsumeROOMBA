using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class ScoreLabel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreLabel;

    void Start()
    {
        scoreLabel.text = 0.ToString();
        GameController gc = GetComponent<GameController>();
        GetComponent<GameController>().Score.Subscribe(x => {
            scoreLabel.text = x.ToString();
        });
    }
}
