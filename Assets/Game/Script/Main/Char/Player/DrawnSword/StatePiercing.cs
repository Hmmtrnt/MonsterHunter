/*突き*/

using UnityEngine;

public partial class PlayerState
{
    public class StatePiercing : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner._drawnIdleMotion = true;

            owner._attackFrame = 0;

            //owner._AtCol.SetActive(true);
            //owner._AtCol.transform.position = new Vector3(owner.transform.position.x + owner.transform.forward.x * 5.0f, 
            //    5.0f, 
            //    owner.transform.position.z + owner.transform.forward.z *5.0f);
        }

        public override void OnUpdate(PlayerState owner)
        {

        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            owner._attackFrame++;
            Debug.Log(owner._attackFrame);
            Debug.Log("踏み込み斬り");
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner._drawnIdleMotion = false;
            owner._AtCol.SetActive(false);
            owner._attackFrame = 0;
        }

        public override void OnChangeState(PlayerState owner)
        {
            // アイドル.
            if (owner._attackFrame >= 60)
            {
                owner.ChangeState(_idleDrawnSword);
            }
            // 突き.
            else if (owner._attackFrame >= 40 && owner._input._YButtonDown)
            {

            }
            // 気刃斬り1.
            else if (owner._attackFrame >= 40 && owner._input._RightTrigger >= 0.5)
            {

            }

        }
    }
}

