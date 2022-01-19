using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    /// <summary>
    /// 移動中か
    /// </summary>
    bool IsMoving{ get; }

    /// <summary>
    /// 最新の移動位置
    /// </summary>
    Vector3 LatestPos{ get; }

    /// <summary>
    /// 設定されている移動に使用する予定の座標2点
    /// </summary>
    Vector3[] MovingLine{ get; }

    /// <summary>
    /// Moveを使用する際に使用する始点終点のデータを設定する
    /// </summary>
    /// <param name="startPoint">出発地点</param>
    /// <param name="endPoint">ゴール地点</param>
    /// <param name="moveValue">移動時の計算に使用する係数(実装によって値の単位と上限が変わる)</param>
    /// <returns>移動させる位置</returns>
    void SetMoveData(Vector3 startPoint,Vector3 endPoint,float moveValue);

    /// <summary>
    /// 移動させる位置を計算する
    /// </summary>
    /// <param name="startPoint">出発地点</param>
    /// <param name="endPoint">ゴール地点</param>
    /// <param name="moveValue">移動時の計算に使用する係数(実装によって値の単位と上限が変わる)</param>
    /// <returns>移動させる位置</returns>
    Vector3 CalculatePosition(Vector3 startPoint,Vector3 endPoint,float moveValue);

    /// <summary>
    /// 実際に移動させる
    /// 移動させる位置
    /// </summary>
    /// <param name="deltatime">1フレームの更新にかかった時間</param>
    /// <returns>移動した位置</returns>
    Vector3 Move(float deltatime);

    /// <summary>
    /// 移動を開始する
    /// </summary>
    void Start();

    /// <summary>
    /// 移動を停止する
    /// </summary>
    void Stop();
}
