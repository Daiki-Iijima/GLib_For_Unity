using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMoveTest: MonoBehaviour
{
    private IMove move;

    [SerializeField] private Transform _targetTransform = null;

    [SerializeField] private Transform _startTransform;
    [SerializeField] private Transform _endTransform;

    [SerializeField] private float _targetTime = 0f;
 
    void Start()
    {
        //  移動モデルをインスタンス化
        move = new TimeMove();

        //  移動先を登録
        move.SetMoveData(_startTransform.position,_endTransform.position,_targetTime);
        //  移動を開始
        move.Start();
    }

    void Update()
    {
        if (move.IsMoving)
        {
            Vector3 pos = move.Move(Time.deltaTime);
            //  動かす
            _targetTransform.position = pos;
        }else{
            Debug.Log("停止中 or 終了");
        }
    }
}
