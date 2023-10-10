using UnityEngine;

public partial class PlayerStateSample
{
    public class StateAvoid : PlayerStateBase
    {
        public override void OnEnter(PlayerStateSample owner, PlayerStateBase prevState)
        {
        }

        public override void OnUpdate(PlayerStateSample owner)
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

        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            owner._avoidTime++;
            MoveAvoid(owner);


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


