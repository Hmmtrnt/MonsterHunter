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
            if(ControllerManager._inctance._LeftStickHorizontal != 0 ||
                ControllerManager._inctance._LeftStickVertical !=0)
            {
                // �ړ�
            }
            else if(ControllerManager._inctance._LeftStickHorizontal == 0 &&
                ControllerManager._inctance._LeftStickVertical==0)
            {
                // �A�C�h��
            }
        }
    }
}


