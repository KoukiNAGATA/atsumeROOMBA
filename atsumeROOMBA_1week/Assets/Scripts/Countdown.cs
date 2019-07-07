using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countdownLabel;
    [SerializeField]
    private GameObject countdown;

    // Start is called before the first frame update
    void Start()
    {
        GameController gc = GetComponent<GameController>();

        gc.Count.Subscribe(count => countdownLabel.text = count > 0 ? count.ToString() : gc.StateValue == GameState.Countdown ? "Go" : "Finish");
        gc.State.Subscribe(state =>
        {
            if (state == GameState.Countdown || state == GameState.PlayingCountdown)
            {
                countdown.SetActive(true);
            }
            else
            {
                countdown.SetActive(false);
            }
        });
    }
}
