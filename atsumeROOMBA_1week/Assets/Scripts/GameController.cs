﻿using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int TIME = 60;

    public int CountValue => _count.Value;
    internal GameState StateValue => _state.Value;

    private IntReactiveProperty _count = new IntReactiveProperty();
    public IReadOnlyReactiveProperty<int> Count => _count;

    private ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>();
    internal IReadOnlyReactiveProperty<GameState> State => _state;

    [System.NonSerialized]
    public BoolReactiveProperty Disable = new BoolReactiveProperty(false);

    [System.NonSerialized]
    public IntReactiveProperty Score = new IntReactiveProperty(0);

    [System.NonSerialized]
    public IntReactiveProperty Bottle = new IntReactiveProperty(0);

    [System.NonSerialized]
    public IntReactiveProperty Box = new IntReactiveProperty(0);

    [System.NonSerialized]
    public IntReactiveProperty Desk = new IntReactiveProperty(0);

    // Start is called before the first frame update
    void Start()
    {
        //Debug用
        Count.Subscribe(x => Debug.Log("count: " + x));
        State.Subscribe(x => Debug.Log("state: " + x));
        Disable.Subscribe(x => Debug.Log("disable: " + x));
        Score.Subscribe(x => Debug.Log("score: " + x));

        _state.Value = GameState.Init;
        StartCoroutine("GameFlow");
    }


    private IEnumerator GameFlow()
    {
        //カウントダウン
        _state.Value = GameState.Countdown;
        for (int count = 3; count >= 0; count--)
        {
            _count.Value = count;
            yield return new WaitForSeconds(1);
        }

        //Playing
        _state.Value = GameState.Playing;
        for (int count = TIME; count > 10; count--)
        {
            _count.Value = count;
            yield return new WaitForSeconds(1);
        }

        //PlayingCountdown
        _state.Value = GameState.PlayingCountdown;
        for (int count = 10; count >= 0; count--)
        {
            _count.Value = count;
            yield return new WaitForSeconds(1);
        }

        //Finish
        _state.Value = GameState.Finish;
        yield return new WaitForSeconds(2);

        //Result
        _state.Value = GameState.Result;
    }
}
