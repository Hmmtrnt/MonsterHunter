using UnityEngine;

public partial class PlayerStateSample
{
    public class StateRunning : PlayerStateBase
    {
        public override void OnEnter(PlayerStateSample owner, PlayerStateBase prevState)
        {
            if(prevState is StateIdle)
            {
                // 前の状態がアイドル状態ならの処理
            }
        }

        public override void OnUpdate(PlayerStateSample owner)
        {

            if (ControllerManager._inctance._RBButtonDown)
            {
                owner._moveVelocityMagnification = owner._moveVelocityDashMagnigication;
            }
            else if (ControllerManager._inctance._RBButtonUp)
            {
                owner._moveVelocityMagnification = owner._moveVelocityRunMagnification;
            }

            if (owner._leftStickHorizontal == 0 &&
                owner._leftStickVertical == 0)
            {
                owner.ChangeState(_idle);
            }

            if (ControllerManager._inctance._AButtonDown)
            {
                owner.ChangeState(_avoid);
            }
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            


            Move(owner);
            RotateDirection(owner);
        }

        // 移動
        private void Move(PlayerStateSample owner)
        {
            owner._rigidbody.velocity = new Vector3(owner._moveVelocity.x, owner._gravity, owner._moveVelocity.z);
        }

        // 移動している方向に回転
        private void RotateDirection(PlayerStateSample owner)
        {
            owner._transform.LookAt(owner._transform.position + owner._moveDirection);
        }

    }
}

