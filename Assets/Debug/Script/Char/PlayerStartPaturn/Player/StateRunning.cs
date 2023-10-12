/*走る*/

using UnityEngine;

public partial class PlayerStateSample
{
    public class StateRunning : StateBase
    {
        public override void OnEnter(PlayerStateSample owner, StateBase prevState)
        {
            if(prevState is StateIdle)
            {
                // 前の状態がアイドル状態ならの処理
            }
        }

        public override void OnUpdate(PlayerStateSample owner)
        {
            if(!owner._UnsheathedSword)
            {
                ChangeMoveSpeed(owner);
                ChangeDashFlag(owner);
            }
            else
            {
                owner._isDashing = false;
                owner._moveVelocityMagnification = owner._moveVelocityRunMagnification;
            }
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            Move(owner);
            RotateDirection(owner);
        }

        public override void OnExit(PlayerStateSample owner, StateBase nextState)
        {
            owner._isDashing = false;
            owner._moveVelocityMagnification = owner._moveVelocityRunMagnification;
        }

        public override void OnChangeState(PlayerStateSample owner)
        {
            // アイドル状態へ
            if (owner._leftStickHorizontal == 0 &&
                owner._leftStickVertical == 0)
            {
                owner.ChangeState(_idle);
            }

            // 回避状態へ
            if (ControllerManager._inctance._AButtonDown)
            {
                owner.ChangeState(_avoid);
            }

            // 回復状態へ
            // HACK:アイテムが選ばれている状態の条件も追加する
            if (ControllerManager._inctance._XButtonDown && !owner._UnsheathedSword)
            {
                owner.ChangeState(_recovery);
            }
        }

        // 移動
        private void Move(PlayerStateSample owner)
        {
            owner._rigidbody.velocity = owner._moveVelocity * owner._moveVelocityMagnification + new Vector3(0.0f, owner._gravity, 0.0f);
        }

        // 移動している方向に回転
        private void RotateDirection(PlayerStateSample owner)
        {
            owner._transform.LookAt(owner._transform.position + owner._moveVelocity);
        }

        // 移動速度の変更
        private void ChangeMoveSpeed(PlayerStateSample owner)
        {
            if (ControllerManager._inctance._RBButton)
            {
                owner._moveVelocityMagnification = owner._moveVelocityDashMagnigication;
            }
            else if (ControllerManager._inctance._RBButtonUp)
            {
                owner._moveVelocityMagnification = owner._moveVelocityRunMagnification;
            }
        }

        // ダッシュしているかどうかの取得
        private void ChangeDashFlag(PlayerStateSample owner)
        {
            if (ControllerManager._inctance._RBButton)
            {
                owner._isDashing = true;
            }
            if(ControllerManager._inctance._RBButtonUp)
            {
                owner._isDashing = false;
            }
        }


    }
}

