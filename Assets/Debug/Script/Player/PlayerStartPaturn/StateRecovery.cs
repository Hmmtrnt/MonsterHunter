/*‰ñ•œ*/

using UnityEngine;

public partial class PlayerStateSample
{
    public class StateRecovery : PlayerStateBase
    {
        public override void OnEnter(PlayerStateSample owner, PlayerStateBase prevState)
        {
            owner._isRecovery = true;
        }

        public override void OnUpdate(PlayerStateSample owner)
        {
            
        }

        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            owner._currentRecoveryTime++;

            Move(owner);
            RotateDirection(owner);

            
        }

        public override void OnExit(PlayerStateSample owner, PlayerStateBase nextState)
        {
            owner._isRecovery = false;
        }

        public override void OnChangeState(PlayerStateSample owner)
        {
            // ó‘Ô‘JˆÚ‚ª‚Å‚«‚é‚©‚Ç‚¤‚©
            bool isChange = owner._currentRecoveryTime >= owner._maxRecoveryTime;
            // “®‚¢‚Ä‚¢‚é‚©‚Ç‚¤‚©
            bool isMove = owner._leftStickHorizontal != 0 || owner._leftStickVertical != 0;

            // ƒAƒCƒhƒ‹ó‘Ô‚Ö
            if (isChange && !isMove)
            {
                owner.ChangeState(_idle);
            }
            else if(isChange && isMove)
            {
                owner.ChangeState(_running);
            }
        }

        // ˆÚ“®
        private void Move(PlayerStateSample owner)
        {
            owner._rigidbody.velocity = owner._moveVelocity * owner._moveVelocityRecoveryMagnification + new Vector3(0.0f, owner._gravity, 0.0f);
        }

        // ˆÚ“®‚µ‚Ä‚¢‚é•ûŒü‚É‰ñ“]
        private void RotateDirection(PlayerStateSample owner)
        {
            owner._transform.LookAt(owner._transform.position + owner._moveVelocity);
        }
    }

}