using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class NoPowerAlert : MonoBehaviour
{
    [SerializeField]
    private GameObject alertPanel;
    [SerializeField]
    private TextMeshProUGUI alertMessage;

    void Start()
    {
        Invoke("_Start", 0.1f);
    }

    void _Start() {
        GameController gc = GetComponent<GameController>();
        alertPanel.SetActive(false);
        gc.Disable.Where(_ => gc.StateValue != GameState.Result).Subscribe(x => {
            alertPanel.SetActive(x);
            StartCoroutine(DisableUI());
        });

        gc.State.Where(state => state == GameState.Result).Subscribe(_ => alertPanel.SetActive(false));
    }

    IEnumerator DisableUI()
    {
        string[] number = new string[] {"ぜろ", "いち", "に", "さん", "よん", "ご"};
        for (int i = 0; i < 5; i++)
        {
            alertMessage.text = "じゅうでんぎれで\nうごけません\nあと " + number[5 - i] + " びょう";
            yield return new WaitForSeconds(1.0f);
        }
    }
}
