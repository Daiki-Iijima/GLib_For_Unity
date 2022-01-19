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
        //  2点間の増加量を求める
        float increasingX = endPoint.x - startPoint.x;
        float increasingY = endPoint.y - startPoint.y;
        float increasingZ = endPoint.z - startPoint.z;

        //  増加量を方向ベクトル化
        Vector3 dir = new Vector3(increasingX, increasingY, increasingZ);

        //  方向ベクトルを単位ベクトル化する
        Vector3 nDir = dir.normalized;

        //  移動量を掛ける
        nDir *= moveValue;

        return nDir;
    }

    public Vector3 Move(float deltatime)
    {
        //  移動中
        if (IsMoving)
        {
            //  1秒にどれくらい移動させるかを割り出す
            float value = _targetLength * deltatime;

            //  座標計算
            LatestPos += CalculatePosition(_startPoint, _endPoint, value);

            //  目標地点についた
            if (Vector3.Distance(LatestPos,_endPoint) <= value)
            {
                IsMoving = false;
                return _endPoint;
            }

            return LatestPos;
        }
        else        //  停止中
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
