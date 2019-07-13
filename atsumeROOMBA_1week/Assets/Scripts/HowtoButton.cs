using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HowtoButton : MonoBehaviour
{
    [SerializeField]
    private GameObject howtoPanel;

    public void OnClick()
    {
        Debug.Log("Show how to play");
        howtoPanel.SetActive(true);
    }
}
