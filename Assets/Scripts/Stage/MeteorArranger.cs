using System.Collections.Generic;
using UnityEngine;

namespace Stage
{
    public class MeteorArranger : MonoBehaviour
    {
        [SerializeField] private int _meteorCount;
        [SerializeField] private float _positionRangeX;
        [SerializeField] private float _positionRangeY;
        [SerializeField] private float _positionRangeZ;
        [SerializeField] private float _scaleMin;
        [SerializeField] private float _scaleMax;

        void OnEnable()
        {
            var meteors = new List<GameObject>
            {
                (GameObject)Resources.Load("Meteor/Meteor1"),
                (GameObject)Resources.Load("Meteor/Meteor2"),
                (GameObject)Resources.Load("Meteor/Meteor3"),
                (GameObject)Resources.Load("Meteor/Meteor4"),
            };

            for (int i = 0; i < _meteorCount; i++)
            {
                var prefab = meteors[Random.Range(0, meteors.Count)];
                var position = new Vector3(
                    Random.Range(-_positionRangeX, _positionRangeX),
                    Random.Range(-_positionRangeY, _positionRangeY),
                    Random.Range(-_positionRangeZ, _positionRangeZ)
                );
                var rotation = Quaternion.Euler(
                    Random.Range(0f, 359f),
                    Random.Range(0f, 359f),
                    Random.Range(0f, 359f)
                );
                var instance = Instantiate(prefab, position, rotation);
                instance.transform.localScale *= Random.Range(_scaleMin, _scaleMax);
            }
        }
    }
}