using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    /// <summary>
    /// �ړ�����
    /// </summary>
    bool IsMoving{ get; }

    /// <summary>
    /// �ŐV�̈ړ��ʒu
    /// </summary>
    Vector3 LatestPos{ get; }

    /// <summary>
    /// �ݒ肳��Ă���ړ��Ɏg�p����\��̍��W2�_
    /// </summary>
    Vector3[] MovingLine{ get; }

    /// <summary>
    /// Move���g�p����ۂɎg�p����n�_�I�_�̃f�[�^��ݒ肷��
    /// </summary>
    /// <param name="startPoint">�o���n�_</param>
    /// <param name="endPoint">�S�[���n�_</param>
    /// <param name="moveValue">�ړ����̌v�Z�Ɏg�p����W��(�����ɂ���Ēl�̒P�ʂƏ�����ς��)</param>
    /// <returns>�ړ�������ʒu</returns>
    void SetMoveData(Vector3 startPoint,Vector3 endPoint,float moveValue);

    /// <summary>
    /// �ړ�������ʒu���v�Z����
    /// </summary>
    /// <param name="startPoint">�o���n�_</param>
    /// <param name="endPoint">�S�[���n�_</param>
    /// <param name="moveValue">�ړ����̌v�Z�Ɏg�p����W��(�����ɂ���Ēl�̒P�ʂƏ�����ς��)</param>
    /// <returns>�ړ�������ʒu</returns>
    Vector3 CalculatePosition(Vector3 startPoint,Vector3 endPoint,float moveValue);

    /// <summary>
    /// ���ۂɈړ�������
    /// �ړ�������ʒu
    /// </summary>
    /// <param name="deltatime">1�t���[���̍X�V�ɂ�����������</param>
    /// <returns>�ړ������ʒu</returns>
    Vector3 Move(float deltatime);

    /// <summary>
    /// �ړ����J�n����
    /// </summary>
    void Start();

    /// <summary>
    /// �ړ����~����
    /// </summary>
    void Stop();
}
