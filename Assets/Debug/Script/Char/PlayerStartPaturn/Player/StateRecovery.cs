/*��*/

using UnityEngine;

public partial class PlayerStateSample
{
    public class StateRecovery : StateBase
    {
        public override void OnEnter(PlayerStateSample owner, StateBase prevState)
        {
            owner._isRecovery = true;
        }

        public override void OnUpdate(PlayerStateSample owner)
        {
            
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            owner._currentRecoveryTime++;

            Move(owner);

            if (owner._currentRecoveryTime <= 50) return;
            
            RotateDirection(owner);
            

            
        }

        public override void OnExit(PlayerStateSample owner, StateBase nextState)
        {
            owner._isRecovery = false;
            owner._currentRecoveryTime = 0;
        }

        public override void OnChangeState(PlayerStateSample owner)
        {
            // ��ԑJ�ڂ��ł��邩�ǂ���
            bool isChange = owner._currentRecoveryTime >= owner._maxRecoveryTime;
            // �����Ă��邩�ǂ���
            bool isMove = owner._leftStickHorizontal != 0 || owner._leftStickVertical != 0;

            // �A�C�h����Ԃ�
            if (isChange && !isMove)
            {
                owner.ChangeState(_idle);
            }
            else if(isChange && isMove)
            {
                owner.ChangeState(_running);
            }
            else if(ControllerManager._inctance._AButtonDown)
            {
                owner.ChangeState(_avoid);
            }
        }

        // �ړ�
        private void Move(PlayerStateSample owner)
        {
            owner._rigidbody.velocity = owner._moveVelocity * owner._moveVelocityRecoveryMagnification + new Vector3(0.0f, owner._gravity, 0.0f);
        }

        // �ړ����Ă�������ɉ�]
        private void RotateDirection(PlayerStateSample owner)
        {
            owner._transform.LookAt(owner._transform.position + owner._moveVelocity);
        }
    }

}