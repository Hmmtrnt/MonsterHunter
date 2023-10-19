/*モンスターステート*/

using UnityEngine;

public partial class MonsterState : MonoBehaviour
{
    public static readonly MonsterStateIdle _idle = new();
    public static readonly MonsterStateRun _run = new();

    // 現在のState.
    private StateBase _currentState = _idle;

    private void Start()
    {
        Initialization();
        _currentState.OnEnter(this, null);
    }

    private void Update()
    {
        _currentState.OnUpdate(this);
        _currentState.OnChangeState(this);
    }

    private void FixedUpdate()
    {
        _currentState.OnFixedUpdate(this);
    }

    // ステートの変更.
    private void ChangeState(StateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }

    private void Initialization()
    {
        _Hunter = GameObject.Find("Hunter");
    }

}
