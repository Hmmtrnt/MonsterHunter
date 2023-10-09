using UnityEngine;

public partial class PlayerStateSample
{
    /// <summary>
    /// ƒAƒCƒhƒ‹ó‘Ô
    /// </summary>
    public class StateIdle : PlayerStateBase
    {
        public override void OnUpdate(PlayerStateSample owner)
        {
            if(ControllerManager._inctance._LeftStickHorizontal != 0 ||
                ControllerManager._inctance._LeftStickVertical !=0)
            {
                // ˆÚ“®
                owner.ChangeState(_running);
            }

            if(ControllerManager._inctance._AButtonDown)
            {
                // ‚µ‚á‚ª‚Şˆ—
            }
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {

        }
    }
}


