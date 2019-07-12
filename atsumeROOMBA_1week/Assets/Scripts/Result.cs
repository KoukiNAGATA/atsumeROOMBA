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
            resultMessage.text = template(10,0,0,50);
        });
    }

    string template(int bin, int box, int desk, int score)
    {
        return "けっか\nあきびん：" + bin + "\nあきばこ：" + box + "\nもくざい：" + desk + "\n\nとくてん：" + score + "てん";
    }
}
