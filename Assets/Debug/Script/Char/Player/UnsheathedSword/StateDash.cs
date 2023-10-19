/*ダッシュ*/

using UnityEngine;

public partial class PlayerState
{
    public class StateDash : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner._runMotion = true;
            owner._isDashing = true;
            owner._moveVelocityMagnification = owner._moveVelocityDashMagnigication;
        }

        public override void OnUpdate(PlayerState owner)
        {

        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            Move(owner);
            RotateDirection(owner);
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner._runMotion = false;
            owner._isDashing = false;
        }

        public override void OnChangeState(PlayerState owner)
        {
            // idle状態.
            if(owner._leftStickHorizontal == 0 &&
                owner._leftStickVertical == 0)
            {
                owner.ChangeState(_idle);
            }

            // run状態.
            if (owner._input._RBButtonUp)
            {
                owner.ChangeState(_running);
            }

            // avoid状態.
            if (owner._input._AButtonDown)
            {
                owner.ChangeState(_avoid);
            }

            // 回復状態へ.
            // HACK:アイテムが選ばれている状態の条件も追加する
            if (owner._input._XButtonDown && !owner._UnsheathedSword)
            {
                owner.ChangeState(_recovery);
            }
        }

        // 移動
        private void Move(PlayerState owner)
        {
            owner._rigidbody.velocity = owner._moveVelocity * owner._moveVelocityMagnification + new Vector3(0.0f, owner._gravity, 0.0f);
        }

        // 移動している方向に回転
        private void RotateDirection(PlayerState owner)
        {
            owner._transform.LookAt(owner._transform.position + owner._moveVelocity);
        }
    }
}