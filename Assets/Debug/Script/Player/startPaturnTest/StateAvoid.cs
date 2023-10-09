using UnityEngine;

public partial class PlayerStateSample
{
    public class StateAvoid : PlayerStateBase
    {
        public override void OnUpdate(PlayerStateSample owner)
        {

            if (owner._avoidTime >= owner._avoidMaxTime)
            {
                owner._avoidTime = 0;
                // �X�e�B�b�N�X���Ă�����Run��
                if (owner._leftStickHorizontal != 0 ||
                    owner._leftStickVertical != 0)
                {
                    owner.ChangeState(_running);
                }
                else if (owner._leftStickHorizontal == 0 &&
                    owner._leftStickVertical == 0)
                {
                    owner.ChangeState(_idle);
                }
            }
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            owner._avoidTime++;
            
        }
    }
}


