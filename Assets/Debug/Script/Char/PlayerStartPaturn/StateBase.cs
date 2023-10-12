/// <summary>
/// State�̒��ۃN���X
/// </summary>

public abstract class StateBase
{
    /// <summary>
    /// �X�e�[�g�J�n���Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    /// <param name="prevState">�ЂƂO�̏��</param>
    public virtual void OnEnter(PlayerStateSample owner, StateBase prevState) { }
    /// <summary>
    /// Update
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnUpdate(PlayerStateSample owner) { }
    /// <summary>
    /// FixedUpdate
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnFixedUpdate(PlayerStateSample owner) { }
    /// <summary>
    /// �X�e�[�g�I�����Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    /// <param name="nextState">���̏��</param>
    public virtual void OnExit(PlayerStateSample owner, StateBase nextState) { }
    /// <summary>
    /// �X�e�[�g�J�ڂ̌Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnChangeState(PlayerStateSample owner) { }
}
