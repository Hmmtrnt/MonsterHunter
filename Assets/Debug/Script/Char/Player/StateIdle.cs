/*アイドル*/

using UnityEngine;

public partial class PlayerState
{
    /// <summary>
    /// アイドル状態.
    /// </summary>
    public class StateIdle : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {

        }

        public override void OnUpdate(PlayerState owner)
        {

        }

        public override void OnFixedUpdate(PlayerState owner)
        {

        }

        public override void OnChangeState(PlayerState owner)
        {
            if (owner._leftStickHorizontal != 0 ||
                owner._leftStickVertical != 0)
            {
                // 移動.
                owner.ChangeState(_running);
            }

            // HACK:のちにアイテムが何を選ばれているか.
            if (owner._input._XButtonDown && !owner._UnsheathedSword)
            {
                // 回復.
                owner.ChangeState(_recovery);
            }
        }

        
    }
}


