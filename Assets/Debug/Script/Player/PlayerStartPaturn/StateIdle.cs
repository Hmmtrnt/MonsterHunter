/*�A�C�h��*/

using UnityEngine;

public partial class PlayerStateSample
{
    /// <summary>
    /// �A�C�h�����
    /// </summary>
    public class StateIdle : PlayerStateBase
    {
        public override void OnUpdate(PlayerStateSample owner)
        {

        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {

        }

        public override void OnChangeState(PlayerStateSample owner)
        {
            if (owner._leftStickHorizontal != 0 ||
                owner._leftStickVertical != 0)
            {
                // �ړ�
                owner.ChangeState(_running);
            }

            // HACK:�̂��ɃA�C�e��������I�΂�Ă��邩
            if (ControllerManager._inctance._XButtonDown)
            {
                // ��
                owner.ChangeState(_recovery);
            }
        }

        
    }
}


