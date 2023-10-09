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

            if(ControllerManager._inctance._LeftStickHorizontal == 0 &&
                ControllerManager._inctance._LeftStickVertical == 0)
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
        }

        // 移動
        private void Move(PlayerStateSample owner)
        {
            if(owner._rigidbody.velocity.magnitude <= 10.0f)
            {
                owner._rigidbody.AddForce(owner._moveSpeed, ForceMode.Acceleration);
            }
        }
    }
}

