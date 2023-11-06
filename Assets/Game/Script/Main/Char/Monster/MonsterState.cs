/*モンスターステート*/

using UnityEngine;
using UnityEngine.UI;

public partial class MonsterState : MonoBehaviour
{
    public static readonly MonsterStateIdle _idle = new();// アイドル.
    public static readonly MonsterStateRun _run = new();// 移動.
    public static readonly MonsterStateAt _at = new();// 攻撃(デバッグ用).
    public static readonly MonsterStateRotateAttack _rotate = new();// 回転攻撃.

    // Stateの初期化.
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

        // 攻撃判定の生成
        _debugAttackCol.SetActive(_indicateAttackCol);

        if(_debagHitPoint <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _collisionTag = collision.transform.tag;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _collisionTag = null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            GetOnDamager();
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
        _hunter = GameObject.Find("Hunter");
        _trasnform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _state = _hunter.GetComponent<PlayerState>();
        _line = GetComponent<LineRenderer>();
        _text = GameObject.Find("DebugText").GetComponent<Text>();

        _debugAttackCol = GameObject.FindWithTag("MonsterAtCol");
        
    }

    public float GetMonsterAttack()
    {
        return _debagAttackPower;
    }

    private float GetOnDamager()
    {
        _debagHitPoint = _debagHitPoint - _state.GetHunterAttack();
        return _debagHitPoint;
    }

    public void SetHitPoint(float hitPoint)
    {
        _debagHitPoint = hitPoint;
    }

    public float GetHitPoint()
    {
        return _debagHitPoint;
    }
}
