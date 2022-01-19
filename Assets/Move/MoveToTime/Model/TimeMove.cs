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
    /// 移動させたい地点と時間を設定する
    /// </summary>
    /// <param name="basePos">出発地点</param>
    /// <param name="targetPos">ゴール地点</param>
    /// <param name="time">移動にかける時間</param>
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
        //  XとYの増加量を求める
        float increasingX = endPoint.x - startPoint.x;
        float increasingY = endPoint.y - startPoint.y;
        float increasingZ = endPoint.z - startPoint.z;

        //  移動量を求める
        float x = startPoint.x + increasingX * nValue;
        float y = startPoint.y + increasingY * nValue;
        float z = startPoint.z + increasingZ * nValue;

        return new Vector3(x, y, z);
    }

    public Vector3 Move(float deltatime)
    {
        //  移動中
        if (IsMoving)
        {
            _timer += deltatime;
            float value = _timer / _targetTime; //  指定された時間を1として今の経過時間を計算

            //  目標地点についた
            if (value >= 1)
            {
                IsMoving = false;
                return _endPoint;
            }

            //  座標計算
            LatestPos = CalculatePosition(_startPoint, _endPoint, value);

            return LatestPos;
        }
        else        //  停止中
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
