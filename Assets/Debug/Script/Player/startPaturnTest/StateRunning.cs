using UnityEngine;

public partial class PlayerStateSample
{
    public class StateRunning : PlayerStateBase
    {
        public override void OnEnter(PlayerStateSample owner, PlayerStateBase prevState)
        {
            if(prevState is StateIdle)
            {
                // �O�̏�Ԃ��A�C�h����ԂȂ�̏���
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

        // �ړ�
        private void Move(PlayerStateSample owner)
        {
            owner._rigidbody.velocity = new Vector3(owner._moveVelocity.x, owner._gravity, owner._moveVelocity.z);
        }

        // �ړ����Ă�������ɉ�]
        private void RotateDirection(PlayerStateSample owner)
        {
            owner._transform.LookAt(owner._transform.position + owner._moveDirection);
        }

    }
}

