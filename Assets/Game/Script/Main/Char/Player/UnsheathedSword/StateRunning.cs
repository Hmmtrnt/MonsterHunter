﻿/*走る*/

using UnityEngine;

public partial class PlayerState
{
    public class StateRunning : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner._runMotion = true;
            owner._moveVelocityMagnification = owner._moveVelocityRunMagnification;
        }

        public override void OnUpdate(PlayerState owner)
        {
            owner._moveVelocityMagnification = owner._moveVelocityRunMagnification;
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
            owner._moveVelocityMagnification = owner._moveVelocityRunMagnification;
        }

        public override void OnChangeState(PlayerState owner)
        {
            // アイドル状態へ.
            if (owner._leftStickHorizontal == 0.0f &&
                owner._leftStickVertical == 0.0f)
            {
                owner.ChangeState(_idle);
            }
            // ダッシュ状態へ.
            else if (owner._input._RBButton && owner._stamina >= owner._maxStamina / 5)
            {
                owner.ChangeState(_dash);
            }
            // 疲労ダッシュ状態へ.
            else if(owner._input._RBButton && owner._stamina <= owner._maxStamina / 5)
            {
                owner.ChangeState(_fatigueDash);
            }
            // 回避状態へ.
            else if (owner._input._AButtonDown && owner._stamina >= owner._maxStamina / 10)
            {
                owner.ChangeState(_avoid);
            }
            // 回復状態へ.
            // HACK:アイテムが選ばれている状態の条件も追加する
            else if (owner._input._XButtonDown && !owner._UnsheathedSword)
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

