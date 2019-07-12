using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField]
    private GameObject result;
    [SerializeField]
    private TextMeshProUGUI resultMessage;

    // Start is called before the first frame update
    void Start()
    {
        result.SetActive(false);
        GameController gc = GetComponent<GameController>();
        gc.State.Where(state => state == GameState.Init).Subscribe(state => result.SetActive(false));
        gc.State.Where(state => state == GameState.Result).Subscribe(state => {
            result.SetActive(true);
            resultMessage.text = template(gc.Bottle.Value, gc.Box.Value, gc.Desk.Value, gc.Score.Value);
        });
    }

    string template(int bottle, int box, int desk, int score)
    {
        return "けっか\nあきびん：" + bottle + " こ\nあきばこ：" + box + " こ\nもくざい：" + desk + " こ\n\nとくてん：" + score + "てん";
    }
}
