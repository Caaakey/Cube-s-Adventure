using Unity.Mathematics;
using UnityEngine;

namespace Scenes.Scripts.Components.MonoBehaviours
{
    public class MainCamera : MonoBehaviour
    {
        public static MainCamera Instance;

        [SerializeField] private Camera _camera;
        private float3 _offset;

        private void Awake()
        {
            Instance = this;
            _offset = transform.position;
        }

        public static void SetPosition(float3 position)
            => Instance.transform.position = Instance._offset + position;
    }
}