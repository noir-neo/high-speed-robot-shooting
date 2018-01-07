using System;
using UnityEngine;

namespace Players
{
    [Serializable]
    public struct PlayerParameters
    {
        [SerializeField] private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
        [SerializeField] private float _turnSpeed;
        public float TurnSpeed => _turnSpeed;
        [SerializeField] private int _hp;
        public int Hp => _hp;
    }
}
