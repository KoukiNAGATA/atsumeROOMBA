using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countdownLabel;
    [SerializeField]
    private GameObject countdown;
    [SerializeField]
    private TextMeshProUGUI countdownOnBarLabel;
    [SerializeField]
    private GameObject countdownOnBar;


    void Start()
    {
        GameController gc = GetComponent<GameController>();

        gc.Count.Subscribe(count => countdownLabel.text = count > 0 ? count.ToString() : gc.StateValue == GameState.Countdown ? "Go!" : "Fin");
        gc.Count.Subscribe(count => countdownOnBarLabel.text = count > 0 ? count.ToString() : gc.StateValue == GameState.Countdown ? "Go!" : "Fin");

        gc.State.Where(state => state == GameState.PlayingCountdown).Subscribe(_ => countdown.SetActive(true));

        gc.State.Subscribe(state =>
        {
            if (state == GameState.Countdown)
            {
                countdown.SetActive(true);
            }
            else if(state == GameState.PlayingCountdown)
            {
                countdown.SetActive(true);
                countdown.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            }
        });

        gc.State.Where(state => state == GameState.Playing || state == GameState.Result).Subscribe(_ =>
        {
            countdown.SetActive(false);
        });
    }
}
