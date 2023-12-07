//using UnityEngine;
//using Unity.Entities;

//namespace Execute
//{
//    public class ExecuteAuthoring : MonoBehaviour
//    {
//        class ExecuteBaker : Baker<ExecuteAuthoring>
//        {
//            public override void Bake(ExecuteAuthoring authoring)
//            {
//                var entity = GetEntity(TransformUsageFlags.None);

//                AddComponent<CubeEntity>(entity);
//            }
//        }
//    }
    
//    public struct CubeEntity : IComponentData { }
//}