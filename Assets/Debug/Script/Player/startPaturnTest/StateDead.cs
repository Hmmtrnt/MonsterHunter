using UnityEngine;

public partial class PlayerStateSample
{
    public class StateDead : PlayerStateBase
    {
        public override void OnEnter(PlayerStateSample owner, PlayerStateBase prevState)
        {
            
        }

        public override void OnUpdate(PlayerStateSample owner)
        {
            Debug.Log("Dead");
        }
        public override void OnFixedUpdate(PlayerStateSample owner)
        {
            
        }
    }
}


