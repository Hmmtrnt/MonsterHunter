/// <summary>
/// State�̒��ۃN���X
/// </summary>

public abstract class PlayerStateBase
{
    /// <summary>
    /// �X�e�[�g�J�n���Ăяo��
    /// </summary>
    /// <param name="owner">�v���C���[�ɃA�N�Z�X���邽�߂̎Q��</param>
    /// <param name="prevState">�ЂƂO�̏��</param>
    public virtual void OnEnter(PlayerStateSample owner, PlayerStateBase prevState) { }
    /// <summary>
    /// Update
    /// </summary>
    /// <param name="owner">�v���C���[�ɃA�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnUpdate(PlayerStateSample owner) { }
    /// <summary>
    /// FixedUpdate
    /// </summary>
    /// <param name="owner">�v���C���[�ɃA�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnFixedUpdate(PlayerStateSample owner) { }
    /// <summary>
    /// �X�e�[�g�I�����Ăяo��
    /// </summary>
    /// <param name="owner">�v���C���[�ɃA�N�Z�X���邽�߂̎Q��</param>
    /// <param name="nextState">���̏��</param>
    public virtual void OnExit(PlayerStateSample owner, PlayerStateBase nextState) { }
}
