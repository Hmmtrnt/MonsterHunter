using UnityEngine;

public partial class PlayerStateSample
{
    // Stateのインスタンス
    private static readonly StateIdle _idle = new StateIdle();
    private static readonly StateAvoid _avoid = new StateAvoid();
    private static readonly StateRunning _running = new StateRunning();
    private static readonly StateDead _dead = new StateDead();


    /// <summary>
    /// 現在のState
    /// </summary>
    private PlayerStateBase _currentState = _idle;

    public bool IsDead => _currentState is StateDead;

    // Start()から呼ばれる
    private void OnStart()
    {
        _currentState.OnEnter(this, null);
    }

    private void OnUpdate()
    {
        _currentState.OnUpdate(this);
    }

    // ステート変更
    private void ChangeState(PlayerStateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }

    // 死亡した時に呼ばれる
    private void OnDeath()
    {
        ChangeState(_dead);
    }


}