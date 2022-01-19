using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMoveTest : MonoBehaviour
{
    private IMove move;

    [SerializeField] private Transform _targetTransform = null;

    [SerializeField] private Transform _startTransform;
    [SerializeField] private Transform _endTransform;

    [SerializeField] private float _moveSpeed = 0f; //  1�b�Ԃɉ�m�i�ނ�
 
    void Start()
    {
        //  �ړ����f�����C���X�^���X��
        move = new SpeedMove();

        //  �ړ����o�^
        move.SetMoveData(_startTransform.position,_endTransform.position,_moveSpeed);

        //  �ړ����J�n
        move.Start();
    }

    void Update()
    {
        if (move.IsMoving)
        {
            Vector3 pos = move.Move(Time.deltaTime);
            //  ������
            _targetTransform.position = pos;
        }else{
            Debug.Log("��~�� or �I��");
        }
    }
}
