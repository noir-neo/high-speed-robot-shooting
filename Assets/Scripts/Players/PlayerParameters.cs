using System;
using UnityEngine;

[Serializable]
public struct PlayerParameters
{
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;
    [SerializeField] private float _turnSpeed;
    public float TurnSpeed => _turnSpeed;
}
