using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CountValue => _count.Value;
    internal GameState StateValue => _state.Value;
    public bool DisableValue { get => _disable.Value; set => _disable.Value = value; } 

    private IntReactiveProperty _count = new IntReactiveProperty();
    public IReadOnlyReactiveProperty<int> Count => _count;

    private ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>();
    internal IReadOnlyReactiveProperty<GameState> State => _state;

    private BoolReactiveProperty _disable = new BoolReactiveProperty();
    internal IReadOnlyReactiveProperty<bool> Disable => _disable;

    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(50);

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
