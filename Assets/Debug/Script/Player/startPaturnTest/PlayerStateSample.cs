using UnityEngine;

public partial class PlayerStateSample
{
    // State�̃C���X�^���X
    private static readonly StateIdle _idle = new();
    private static readonly StateAvoid _avoid = new();
    private static readonly StateRunning _running = new();
    private static readonly StateDead _dead = new();


    /// <summary>
    /// ���݂�State
    /// </summary>
    private PlayerStateBase _currentState = _idle;

    public bool IsDead => _currentState is StateDead;

    // Start()����Ă΂��
    private void OnStart()
    {
        _currentState.OnEnter(this, null);
    }

    private void OnUpdate()
    {
        _currentState.OnUpdate(this);
    }

    // �X�e�[�g�ύX
    private void ChangeState(PlayerStateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }

    // ���S�������ɌĂ΂��
    private void OnDeath()
    {
        ChangeState(_dead);
    }


}