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
            Debug.Log("Idle");
            if(ControllerManager._inctance._LeftStickHorizontal != 0 ||
                ControllerManager._inctance._LeftStickVertical !=0)
            {
                Debug.Log("waw");
                // �ړ�
                owner.ChangeState(_running);
            }

            if(ControllerManager._inctance._AButtonDown)
            {
                // ���Ⴊ�ޏ���
            }
        }
    }
}


