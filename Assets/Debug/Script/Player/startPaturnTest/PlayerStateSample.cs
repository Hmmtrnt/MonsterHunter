using UnityEngine;

public partial class PlayerStateSample
{
    // State�̃C���X�^���X
    private static readonly StateIdle _idle = new StateIdle();
    private static readonly StateAvoid _avoid = new StateAvoid();
    private static readonly StateRunning _running = new StateRunning();
    private static readonly StateDead _dead = new StateDead();

    /// <summary>
    /// ���݂�State
    /// </summary>
    private PlayerStateBase _currentState = _idle;

}