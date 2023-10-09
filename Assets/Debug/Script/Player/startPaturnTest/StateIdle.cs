using UnityEngine;

public partial class PlayerStateSample
{
    /// <summary>
    /// アイドル状態
    /// </summary>
    public class StateIdle : PlayerStateBase
    {
        public override void OnUpdate(PlayerStateSample owner)
        {
            Debug.Log("Idle");
            if(ControllerManager._inctance._LeftStickHorizontal != 0 ||
                ControllerManager._inctance._LeftStickVertical !=0)
            {
                // 移動
                owner.ChangeState(_running);
            }

            if(ControllerManager._inctance._AButtonDown)
            {
                // しゃがむ処理
            }
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {

        }
    }
}


