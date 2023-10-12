/*アイドル*/

using UnityEngine;

public partial class PlayerStateSample
{
    /// <summary>
    /// アイドル状態.
    /// </summary>
    public class StateIdle : StateBase
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
                // 移動.
                owner.ChangeState(_running);
            }

            // HACK:のちにアイテムが何を選ばれているか.
            if (ControllerManager._inctance._XButtonDown)
            {
                // 回復.
                owner.ChangeState(_recovery);
            }
        }

        
    }
}


