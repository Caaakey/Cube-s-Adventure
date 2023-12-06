using UnityEngine;
using Unity.Entities;

namespace Execute
{
    public class ExecuteAuthoring : MonoBehaviour
    {
        public bool MainThread;
        public bool IJobEntity;
        
        class ExecuteBaker : Baker<ExecuteAuthoring>
        {
            public override void Bake(ExecuteAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                
                if (authoring.MainThread) AddComponent<MainThread>(entity);
                if (authoring.IJobEntity) AddComponent<IJobEntity>(entity);
            }
        }
    }
    
    public struct MainThread : IComponentData { }
    public struct IJobEntity : IComponentData { }
}