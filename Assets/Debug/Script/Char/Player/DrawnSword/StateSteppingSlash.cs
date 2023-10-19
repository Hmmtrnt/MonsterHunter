/*踏み込み斬り*/

using UnityEngine;

public partial class PlayerState
{
    public class StateSteppingSlash : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner._AtCol.SetActive(true);
            owner._AtCol.transform.position = new Vector3(owner.transform.position.x + owner.transform.forward.x * 5.0f, 
                3.0f, 
                owner.transform.position.z + owner.transform.forward.z *5.0f);
        }

        public override void OnUpdate(PlayerState owner)
        {


        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            DebagAt(owner);
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner._AtCol.SetActive(false);
        }

        public override void OnChangeState(PlayerState owner)
        {
            if(owner._AtCol.transform.position.y <= 0.3f)
            {
                owner.ChangeState(_idleDrawnSword);
            }
        }

        private void DebagAt(PlayerState owner)
        {
            owner._AtCol.transform.position += new Vector3(0.0f, -0.1f, 0.0f);
        }
    }
}


