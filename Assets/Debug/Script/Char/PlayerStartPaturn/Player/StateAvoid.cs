/*回避*/

using UnityEngine;

public partial class PlayerStateSample
{
    public class StateAvoid : StateBase
    {
        public override void OnEnter(PlayerStateSample owner, StateBase prevState)
        {
            owner._isAvoiding = true;
        }

        public override void OnUpdate(PlayerStateSample owner)
        {

            
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            owner._avoidTime++;
            MoveAvoid(owner);
        }

        public override void OnExit(PlayerStateSample owner, StateBase nextState)
        {
            owner._isAvoiding = false;
        }

        public override void OnChangeState(PlayerStateSample owner)
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

        private void MoveAvoid(PlayerStateSample owner)
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


