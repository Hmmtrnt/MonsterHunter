using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAnim : MonoBehaviour
{
    private Animator _animator;

    // アイドル状態.
    private bool _isIdle = true;
    // 走る状態.
    private bool _isRun = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _animator.SetBool("Idle", _isIdle);
        _animator.SetBool("Run", _isRun);
    }

    private bool GetIsIdle()
    { 
        return _isIdle; 
    }
    private bool GetRun()
    { 
        return _isRun; 
    }
}
