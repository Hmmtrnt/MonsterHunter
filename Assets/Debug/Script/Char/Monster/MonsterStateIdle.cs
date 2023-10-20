/*モンスターのアイドル*/

using UnityEngine;

public partial class MonsterState
{
    public class MonsterStateIdle : StateBase
    {
        public override void OnEnter(MonsterState owner, StateBase prevState)
        {
        }

        public override void OnUpdate(MonsterState owner)
        {
        }

        public override void OnFixedUpdate(MonsterState owner)
        {

        }

        public override void OnExit(MonsterState owner, StateBase nextState)
        {

        }

        public override void OnChangeState(MonsterState owner)
        {
            owner.ChangeState(_run);
            if(owner._Hunter != null)
            {
            }
        }
    }
}



