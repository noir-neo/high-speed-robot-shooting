using System;
using System.Linq;
using UnityEngine;

namespace Players
{
    [ExecuteInEditMode]
    public class PlayerLayerConfigurer : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;

        void OnEnable()
        {
            ConfigureLayer();
        }

        private void ConfigureLayer()
        {
            gameObject.layer = LayerMask.NameToLayer(_playerCore.PlayerId.ToString());
        }
    }
}
