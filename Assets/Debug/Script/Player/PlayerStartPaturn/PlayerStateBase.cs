/// <summary>
/// Stateの抽象クラス
/// </summary>

public abstract class PlayerStateBase
{
    /// <summary>
    /// ステート開始時呼び出し
    /// </summary>
    /// <param name="owner">プレイヤーにアクセスするための参照</param>
    /// <param name="prevState">ひとつ前の状態</param>
    public virtual void OnEnter(PlayerStateSample owner, PlayerStateBase prevState) { }
    /// <summary>
    /// Update
    /// </summary>
    /// <param name="owner">プレイヤーにアクセスするための参照</param>
    public virtual void OnUpdate(PlayerStateSample owner) { }
    /// <summary>
    /// FixedUpdate
    /// </summary>
    /// <param name="owner">プレイヤーにアクセスするための参照</param>
    public virtual void OnFixedUpdate(PlayerStateSample owner) { }
    /// <summary>
    /// ステート終了時呼び出し
    /// </summary>
    /// <param name="owner">プレイヤーにアクセスするための参照</param>
    /// <param name="nextState">次の状態</param>
    public virtual void OnExit(PlayerStateSample owner, PlayerStateBase nextState) { }
}
