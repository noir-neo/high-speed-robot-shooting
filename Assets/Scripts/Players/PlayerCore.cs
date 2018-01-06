using UnityEngine;

namespace Players
{
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private PlayerId _playerId;
        public PlayerId PlayerId => _playerId;
        [SerializeField] private PlayerParameters _parameters;
        public PlayerParameters PlayerParameters => _parameters;
    }
}
