using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField]
    private GameObject howtoPanel;

    public void OnClick()
    {
        Debug.Log("Hide how to play");
        howtoPanel.SetActive(false);
    }
}
