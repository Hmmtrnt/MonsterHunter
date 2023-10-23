/*デバッグ用マネージャー*/

using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private GameObject _Monster;
    private MonsterState _monsterState;

    // Start is called before the first frame update
    void Start()
    {
        _monsterState = _Monster.GetComponent<MonsterState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("通っている");
            _monsterState.SetHitPoint(300.0f);
            _Monster.transform.position = new Vector3(180.0f, 2.0f, 95.0f);
            _Monster.SetActive(true);
        }
    }
}
