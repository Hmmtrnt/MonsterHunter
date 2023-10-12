/*プレイヤーステート*/

using UnityEngine;

public partial class PlayerStateSample
{
    // Stateのインスタンス.
    private static readonly StateIdle _idle = new();
    private static readonly StateAvoid _avoid = new();
    private static readonly StateRunning _running = new();
    private static readonly StateRecovery _recovery = new();
    private static readonly StateDead _dead = new();


    // 現在のState.
    private PlayerStateBase _currentState = _idle;

    public bool IsDead => _currentState is StateDead;

    // Startに入れる.
    private void OnStart()
    {
        _currentState.OnEnter(this, null);
    }
    // Updateに入れる.
    private void OnUpdate()
    {
        _currentState.OnUpdate(this);
        _currentState.OnChangeState(this);
    }
    // FixedUpdateに入れる.
    private void OnFixedUpdate()
    {
        _currentState.OnFixedUpdate(this);
    }

    // ステート変更.
    private void ChangeState(PlayerStateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }

    // 死亡した時に呼ばれる.
    private void OnDeath()
    {
        ChangeState(_dead);
    }


}