/*ダメージを受けた時*/

using UnityEngine;

public partial class PlayerState
{
    public class StateDamage : StateBase
    {
        private int _testTime;

        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            _testTime = 0;
            owner._hitPoint = owner._hitPoint - owner._MonsterState.GetMonsterAttack();
        }

        public override void OnUpdate(PlayerState owner)
        {

        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            _testTime++;

            Vector3 dir = owner._transform.position - owner._Monster.transform.position;
            dir = dir.normalized;
            owner._transform.position += dir * -0.1f;
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            
        }

        public override void OnChangeState(PlayerState owner)
        {
            if(_testTime <= 60)
            {
                owner.ChangeState(_idle);
            }
        }
    }

}
