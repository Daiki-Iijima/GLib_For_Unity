using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMove : IMove
{
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    private float _targetLength;

    public bool IsMoving { get; private set; }

    public Vector3 LatestPos { get; private set; }

    public Vector3[] MovingLine { get; }

    public Vector3 CalculatePosition(Vector3 startPoint, Vector3 endPoint, float moveValue)
    {
        //  2�_�Ԃ̑����ʂ����߂�
        float increasingX = endPoint.x - startPoint.x;
        float increasingY = endPoint.y - startPoint.y;
        float increasingZ = endPoint.z - startPoint.z;

        //  �����ʂ�����x�N�g����
        Vector3 dir = new Vector3(increasingX, increasingY, increasingZ);

        //  �����x�N�g����P�ʃx�N�g��������
        Vector3 nDir = dir.normalized;

        //  �ړ��ʂ��|����
        nDir *= moveValue;

        return nDir;
    }

    public Vector3 Move(float deltatime)
    {
        //  �ړ���
        if (IsMoving)
        {
            //  1�b�ɂǂꂭ�炢�ړ������邩������o��
            float value = _targetLength * deltatime;

            //  ���W�v�Z
            LatestPos += CalculatePosition(_startPoint, _endPoint, value);

            //  �ڕW�n�_�ɂ���
            if (Vector3.Distance(LatestPos,_endPoint) <= value)
            {
                IsMoving = false;
                return _endPoint;
            }

            return LatestPos;
        }
        else        //  ��~��
        {
            return LatestPos;
        }
    }

    public void SetMoveData(Vector3 startPoint, Vector3 endPoint, float moveValue)
    {
        _startPoint = startPoint;
        _endPoint = endPoint;
        _targetLength = moveValue;

        LatestPos = _startPoint;
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
