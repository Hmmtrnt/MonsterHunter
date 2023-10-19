/*抜刀アイドル状態*/

using UnityEngine;


public partial class PlayerState
{
    public class StateIdleDrawnSword : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
        }

        public override void OnUpdate(PlayerState owner)
        {

        }

        public override void OnFixedUpdate(PlayerState owner)
        {

        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
        }

        public override void OnChangeState(PlayerState owner)
        {
            // 抜刀移動
            if(owner._leftStickHorizontal != 0 || 
                owner._leftStickVertical != 0)
            {
                owner.ChangeState(_runDrawnSword);
            }

            // 踏み込み斬り
            if (owner._input._YButtonDown)
            {
                owner.ChangeState(_steppingSlash);
            }

            // のちに納刀ステートを入れる
            if (owner._input._XButtonDown || owner._input._RBButtonDown)
            {
                owner.ChangeState(_sheathingSword);
            }

        }
    }
}

