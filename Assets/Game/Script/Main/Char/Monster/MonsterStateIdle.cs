/*モンスターのアイドル*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterState
{
    public class MonsterStateIdle : StateBase
    {
        private int testTime = 0;

        

        public override void OnEnter(MonsterState owner, StateBase prevState)
        {
            testTime = 0;
        }

        public override void OnUpdate(MonsterState owner)
        {
            Vector3 direction = owner._hunter.transform.position - owner._trasnform.position;
            // オブジェクトの正面とプレイヤーの位置の角度取得
            float angle = Vector3.Angle(direction, owner._trasnform.forward);

            if(angle < 80 * 0.5f)
            {
                RaycastHit hit;
                if(Physics.Raycast(owner._trasnform.position, direction.normalized, out hit))
                {
                    if(hit.collider.gameObject == owner._hunter)
                    {
                        //Debug.Log("見つけた");
                        owner._text.text = "見つけた";
                    }
                }
            }
            else
            {
                owner._text.text = "見失った";
            }

            Debug.Log(angle);

            owner._line.SetPosition(0, owner.transform.position);
            owner._line.SetPosition(1, owner._hunter.transform.position);
        }

        public override void OnFixedUpdate(MonsterState owner)
        {
            //testTime++;
        }

        public override void OnExit(MonsterState owner, StateBase nextState)
        {

        }

        public override void OnChangeState(MonsterState owner)
        {
            //if(testTime >= 120.0f)
            //{
            //    owner.ChangeState(_run);
            //}
        }
    }
}



