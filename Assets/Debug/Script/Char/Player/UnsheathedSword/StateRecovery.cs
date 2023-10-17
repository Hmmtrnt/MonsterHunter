/*回復*/

using UnityEngine;

public partial class PlayerState
{
    public class StateRecovery : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner._isRecovery = true;
        }

        public override void OnUpdate(PlayerState owner)
        {
            
        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            owner._currentRecoveryTime++;

            Move(owner);
            RotateDirection(owner);
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner._isRecovery = false;
            owner._currentRecoveryTime = 0;
        }

        public override void OnChangeState(PlayerState owner)
        {
            // 状態遷移ができるかどうか
            bool isChange = owner._currentRecoveryTime >= owner._maxRecoveryTime;
            // 動いているかどうか
            bool isMove = owner._leftStickHorizontal != 0 || owner._leftStickVertical != 0;

            // アイドル状態へ
            if (isChange && !isMove)
            {
                owner.ChangeState(_idle);
            }
            else if(isChange && isMove)
            {
                owner.ChangeState(_running);
            }
            else if(owner._input._AButtonDown)
            {
                owner.ChangeState(_avoid);
            }
        }

        // 移動
        private void Move(PlayerState owner)
        {
            owner._rigidbody.velocity = owner._moveVelocity * owner._moveVelocityRecoveryMagnification + new Vector3(0.0f, owner._gravity, 0.0f);
        }

        // 移動している方向に回転
        private void RotateDirection(PlayerState owner)
        {
            owner._transform.LookAt(owner._transform.position + owner._moveVelocity);
        }
    }

}