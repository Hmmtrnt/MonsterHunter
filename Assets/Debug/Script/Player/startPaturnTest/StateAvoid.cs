using UnityEngine;

public partial class PlayerStateSample
{
    public class StateAvoid : PlayerStateBase
    {
        public override void OnUpdate(PlayerStateSample owner)
        {
            Debug.Log("Avoid");

            if (owner._avoidTime >= owner._avoidMaxTime)
            {
                owner._avoidTime = 0;
                if (owner._leftStickHorizontal != 0 ||
                    owner._leftStickVertical != 0)
                {
                    Debug.Log("as");
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
            
        }
    }
}


