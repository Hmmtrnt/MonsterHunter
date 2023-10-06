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
            if(ControllerManager._inctance._LeftStickHorizontal != 0 ||
                ControllerManager._inctance._LeftStickVertical !=0)
            {
                // 移動
            }
            else if(ControllerManager._inctance._LeftStickHorizontal == 0 &&
                ControllerManager._inctance._LeftStickVertical==0)
            {
                // アイドル
            }
        }
    }
}


