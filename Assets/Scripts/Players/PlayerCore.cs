using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] private PlayerParameters _parameters;
    public PlayerParameters PlayerParameters => _parameters;
}
