using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class PlayerMoveEventPlayerUnitMove : AEvent<Scene, PlayerMoveEvent>
    {
        protected override async ETTask Run(Scene scene, PlayerMoveEvent args)
        {
            Unit unit = args.unit;
            float3 target = args.position;
            List<float3> points = new List<float3>();
            unit.GetComponent<PathfindingComponent>().Find(unit.Position, target, points);
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            moveComponent.MoveToAsync(points, unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed)).NoContext();
            await ETTask.CompletedTask;
        }
    }
}