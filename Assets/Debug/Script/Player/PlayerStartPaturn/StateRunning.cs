/*����*/

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
            ChangeMoveSpeed(owner);
            ChangeDashFlag(owner);
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            Move(owner);
            RotateDirection(owner);
        }

        public override void OnExit(PlayerStateSample owner, PlayerStateBase nextState)
        {
            owner._isDashing = false;
        }

        public override void OnChangeState(PlayerStateSample owner)
        {
            // �A�C�h����Ԃ�
            if (owner._leftStickHorizontal == 0 &&
                owner._leftStickVertical == 0)
            {
                owner.ChangeState(_idle);
            }

            // �����Ԃ�
            if (ControllerManager._inctance._AButtonDown)
            {
                owner._moveVelocityMagnification = owner._moveVelocityRunMagnification;
                owner.ChangeState(_avoid);
            }

            // �񕜏�Ԃ�
            // HACK:�A�C�e�����I�΂�Ă����Ԃ̏������ǉ�����
            if (ControllerManager._inctance._XButtonDown)
            {
                owner.ChangeState(_recovery);
            }
        }

        // �ړ�
        private void Move(PlayerStateSample owner)
        {
            owner._rigidbody.velocity = owner._moveVelocity * owner._moveVelocityMagnification + new Vector3(0.0f, owner._gravity, 0.0f);
        }

        // �ړ����Ă�������ɉ�]
        private void RotateDirection(PlayerStateSample owner)
        {
            owner._transform.LookAt(owner._transform.position + owner._moveVelocity);
        }

        // �ړ����x�̕ύX
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

        // �_�b�V�����Ă��邩�ǂ����̎擾
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

