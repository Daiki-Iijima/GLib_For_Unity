using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMove:IMove
{
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    private float _timer;
    private float _targetTime;

    public bool IsMoving { get; private set; }

    public Vector3[] MovingLine { get { return new Vector3[] { _startPoint, _endPoint }; } }

    public Vector3 LatestPos { get; private set; }

    public TimeMove(){
        LatestPos = Vector3.zero;
    }

    /// <summary>
    /// �ړ����������n�_�Ǝ��Ԃ�ݒ肷��
    /// </summary>
    /// <param name="basePos">�o���n�_</param>
    /// <param name="targetPos">�S�[���n�_</param>
    /// <param name="time">�ړ��ɂ����鎞��</param>
    public void SetMoveData(Vector3 startPoint,Vector3 endPoint,float targetTime){ 
        _startPoint = startPoint;
        _endPoint = endPoint;
        _targetTime = targetTime;
    }

    public virtual void Reset(){
        _timer = 0;
    }

    public Vector3 CalculatePosition(Vector3 startPoint, Vector3 endPoint, float nValue)
    {
        //  X��Y�̑����ʂ����߂�
        float increasingX = endPoint.x - startPoint.x;
        float increasingY = endPoint.y - startPoint.y;
        float increasingZ = endPoint.z - startPoint.z;

        //  �ړ��ʂ����߂�
        float x = startPoint.x + increasingX * nValue;
        float y = startPoint.y + increasingY * nValue;
        float z = startPoint.z + increasingZ * nValue;

        return new Vector3(x, y, z);
    }

    public Vector3 Move(float deltatime)
    {
        //  �ړ���
        if (IsMoving)
        {
            _timer += deltatime;
            float value = _timer / _targetTime; //  �w�肳�ꂽ���Ԃ�1�Ƃ��č��̌o�ߎ��Ԃ��v�Z

            //  �ڕW�n�_�ɂ���
            if (value >= 1)
            {
                IsMoving = false;
                return _endPoint;
            }

            //  ���W�v�Z
            LatestPos = CalculatePosition(_startPoint, _endPoint, value);

            return LatestPos;
        }
        else        //  ��~��
        {
            return LatestPos;
        }
    }

    public void Start()
    {
        IsMoving = true;
    }

    public void Stop()
    {
        IsMoving = false;
    }
}
