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
            Vector3 dir = (owner._Hunter.transform.position - owner.transform.position);

            dir = dir.normalized;
            float x = dir.x * owner._followingSpeed;
            float z = dir.z * owner._followingSpeed;
            //owner.transform.Translate(x / 40, 0, z / 40);

            owner.transform.position += new Vector3(x / 40, 0, z / 40);

            owner.transform.LookAt(new Vector3(owner._Hunter.transform.position.x, 0.0f, owner._Hunter.transform.position.z));
        }

        public override void OnExit(MonsterState owner, StateBase nextState)
        {
            
        }

        public override void OnChangeState(MonsterState owner)
        {
            if (owner._collisionTag == "Player")
            {
                Debug.Log("dfaf");
                owner.ChangeState(_idle);
            }
        }
    }
}


