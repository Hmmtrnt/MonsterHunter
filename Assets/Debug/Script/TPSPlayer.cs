using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSPlayer : MonoBehaviour
{
    // TPSEyeオブジェクト取得
    [SerializeField] private GameObject _TPSEyeObject;

    // 縦の最大回転値
    [SerializeField] private float _MaxTPSEyeRotateX;
    // 縦の最小回転値
    [SerializeField] private float _MinTPSEyeRotateX;

    // 右スティックの入力状態
    private float _RightHorizontal;
    private float _RightVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右スティックの入力状態
        _RightHorizontal = Input.GetAxis("Horizontal2");
        _RightVertical = Input.GetAxis("Vertical2");
         //_RightHorizontal = _RightHorizontal;

        PlayerRotate();
        TPSEyeRotate();
    }

    // プレイヤーの回転
    private void PlayerRotate()
    {
        transform.Rotate(0.0f,_RightHorizontal, 0.0f);
    }

    private void TPSEyeRotate()
    {
        // 回転限界値の場合処理を通さない
        if (_TPSEyeObject.transform.localEulerAngles.x > 200 &&
            _TPSEyeObject.transform.localEulerAngles.x < _MaxTPSEyeRotateX)
        {
            _TPSEyeObject.transform.localEulerAngles = new Vector3(_MaxTPSEyeRotateX, 0.0f, 0.0f);
        }
        else if(_TPSEyeObject.transform.localEulerAngles.x > _MinTPSEyeRotateX &&
            _TPSEyeObject.transform.localEulerAngles.x < 100)
        {
            _TPSEyeObject.transform.localEulerAngles = new Vector3(_MinTPSEyeRotateX, 0.0f, 0.0f);
        }


        //if (_TPSEyeObject.transform.localEulerAngles.x > _MinTPSEyeRotateX &&
          //  _TPSEyeObject.transform.localEulerAngles.x < _MaxTPSEyeRotateX)

            _TPSEyeObject.transform.Rotate(_RightVertical, 0.0f, 0.0f);


        Debug.Log(_TPSEyeObject.transform.localEulerAngles.x);

    }
}
