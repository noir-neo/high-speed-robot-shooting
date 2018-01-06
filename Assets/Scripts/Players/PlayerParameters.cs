using System;
using UnityEngine;

[Serializable]
public struct PlayerParameters
{
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;
}
