/*モンスターの移動*/

using UnityEngine;

public partial class MonsterState
{
    public class MonsterStateRun : StateBase
    {
        public override void OnEnter(MonsterState owner, StateBase prevState)
        {
            
        }

        public override void OnUpdate(MonsterState owner)
        {

        }

        public override void OnFixedUpdate(MonsterState owner)
        {
            Vector3 dir = (owner._Hunter.transform.position - owner.transform.position).normalized;
            float x = dir.x * owner._followingSpeed;
            float z = dir.z * owner._followingSpeed;
            owner.transform.Translate(x / 50, 0, z / 50);
        }

        public override void OnExit(MonsterState owner, StateBase nextState)
        {
            
        }

        public override void OnChangeState(MonsterState owner)
        {
            
        }
    }
}


