using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClick() {
        Debug.Log("Button click!");
        SceneManager.LoadScene("MainScene");
    }
}
