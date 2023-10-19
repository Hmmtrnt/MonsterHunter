// アイドル状態から抜刀状態への移行

using UnityEngine;

public partial class PlayerState
{
    /// <summary>
    /// 抜刀している状態
    /// </summary>
    public class StateDrawnSwordTransition : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner._drawnSword = true;
        }

        public override void OnUpdate(PlayerState owner)
        {

        }

        public override void OnFixedUpdate(PlayerState owner)
        {

        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner._drawnSword = false;
        }

        public override void OnChangeState(PlayerState owner)
        {
            // デバッグ用
            if(owner._input._XButtonDown || owner._input._RBButtonDown)
            {
                owner.ChangeState(_idle);
            }
        }
    }
}