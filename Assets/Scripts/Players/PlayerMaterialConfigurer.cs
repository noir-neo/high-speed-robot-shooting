using System;
using System.Linq;
using UnityEngine;

namespace Players
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Renderer))]
    public class PlayerMaterialConfigurer : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private PlayerMaterialSetting[] _materials;

        [Serializable]
        class PlayerMaterialSetting
        {
            [SerializeField] private PlayerId _playerId;
            public PlayerId PlayerId => _playerId;
            [SerializeField] private Material _material;
            public Material Material => _material;
        }

        void OnEnable()
        {
            ConfigureMaterial();
        }

        void OnValidate()
        {
            ConfigureMaterial();
        }

        private void ConfigureMaterial()
        {
            _renderer.material = _materials.First(m => m.PlayerId == _playerCore.PlayerId).Material;
        }
    }
}
