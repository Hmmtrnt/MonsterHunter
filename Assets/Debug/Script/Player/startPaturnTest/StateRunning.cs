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

        }
    }
}

