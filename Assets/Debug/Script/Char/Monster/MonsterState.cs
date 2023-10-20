/*モンスターステート*/

using UnityEngine;

public partial class MonsterState : MonoBehaviour
{
    public static readonly MonsterStateIdle _idle = new();// アイドル.
    public static readonly MonsterStateRun _run = new();// 移動.
    public static readonly MonsterStateAt _at = new();// 攻撃(デバッグ用).

    // 現在のState.
    private StateBase _currentState = _idle;

    private void Start()
    {
        Initialization();
        _currentState.OnEnter(this, null);
    }

    private void Update()
    {
        _currentState.OnUpdate(this);
        _currentState.OnChangeState(this);
    }

    private void FixedUpdate()
    {
        _currentState.OnFixedUpdate(this);

        if(_debagHitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            _collisionTag = collision.transform.tag;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            _collisionTag = null;
        }
    }

    // ステートの変更.
    private void ChangeState(StateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }

    private void Initialization()
    {
        _Hunter = GameObject.Find("Hunter");
    }

    public float GetMonsterAttack()
    {
        return _debagAttackPower;
    }
}
