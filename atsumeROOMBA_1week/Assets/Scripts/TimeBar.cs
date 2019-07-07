﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimeBar : MonoBehaviour
{
    [SerializeField]
    private Slider timebar;

    private float time;
    private bool onPlay = false;

    void Start()
    {
        GameController gc = GetComponent<GameController>();
        gc.State.Where(state => state == GameState.Playing).Subscribe(_ => {
                onPlay = true;
                time = 60f;
            });
        gc.State.Where(state => state == GameState.Finish).Subscribe(_ => onPlay = false);
    }

    void Update()
    {
        if (onPlay)
        {
            time -= Time.deltaTime;
            timebar.value = time / 60f;
        }
    }
}