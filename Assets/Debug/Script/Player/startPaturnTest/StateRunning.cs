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
            Debug.Log("Run");

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
    }
}

