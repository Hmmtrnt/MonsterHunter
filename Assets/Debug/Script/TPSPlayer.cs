using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSPlayer : MonoBehaviour
{
    // TPSEye�I�u�W�F�N�g�擾
    [SerializeField] private GameObject _TPSEyeObject;

    // �c�̍ő��]�l
    [SerializeField] private float _MaxTPSEyeRotateX;
    // �c�̍ŏ���]�l
    [SerializeField] private float _MinTPSEyeRotateX;

    // �E�X�e�B�b�N�̓��͏��
    private float _RightHorizontal;
    private float _RightVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �E�X�e�B�b�N�̓��͏��
        _RightHorizontal = Input.GetAxis("Horizontal2");
        _RightVertical = Input.GetAxis("Vertical2");
         //_RightHorizontal = _RightHorizontal;

        PlayerRotate();
        TPSEyeRotate();
    }

    // �v���C���[�̉�]
    private void PlayerRotate()
    {
        transform.Rotate(0.0f,_RightHorizontal, 0.0f);
    }

    private void TPSEyeRotate()
    {
        // ��]���E�l�̏ꍇ������ʂ��Ȃ�
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
