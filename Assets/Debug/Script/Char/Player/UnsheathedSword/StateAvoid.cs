/*回避*/

using UnityEngine;

public partial class PlayerState
{
    public class StateAvoid : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner._isAvoiding = true;
        }

        public override void OnUpdate(PlayerState owner)
        {

            
        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            owner._avoidTime++;
            MoveAvoid(owner);
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner._isAvoiding = false;
        }

        public override void OnChangeState(PlayerState owner)
        {
            if (owner._avoidTime >= owner._avoidMaxTime)
            {
                owner._avoidTime = 0;
                owner._rigidbody.velocity = Vector3.zero;
                // スティック傾けていたらRunに
                if (owner._leftStickHorizontal != 0 ||
                    owner._leftStickVertical != 0)
                {
                    owner.ChangeState(_running);
                }
                else if (owner._leftStickHorizontal == 0 &&
                    owner._leftStickVertical == 0)
                {
                    owner.ChangeState(_idle);
                }
            }
        }

        private void MoveAvoid(PlayerState owner)
        {
            //owner._rigidbody.AddForce(owner._avoidVelocity, ForceMode.Impulse);
            owner._rigidbody.velocity = owner._avoidVelocity;

            if(owner._avoidTime <= 10)
            {
                owner._rigidbody.velocity *= 0.5f;
            }
            
        }
    }
}


