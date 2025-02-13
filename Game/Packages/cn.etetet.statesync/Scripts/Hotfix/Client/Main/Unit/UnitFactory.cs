using System;
//using Unity.Mathematics;

namespace ET.Client
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        unitComponent.Add(unit);
	        
	        unit.Position = unitInfo.Position;
	        unit.Forward = unitInfo.Forward;
	        
	        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

			// foreach (var kv in unitInfo.KV)
			// {
			// 	numericComponent.Set(kv.Key, kv.Value);
			// }
	        
	        unit.AddComponent<MoveComponent>();
		   //      if (unitInfo.MoveInfo != null)
		   //      {
			  //       if (unitInfo.MoveInfo.Points.Count > 0)
					// {
					// 	unitInfo.MoveInfo.Points[0] = unit.Position;
					// 	unit.MoveToAsync(unitInfo.MoveInfo.Points).NoContext();
					// }
		   //      }

	        unit.AddComponent<ObjectWait>();

	        // unit.AddComponent<XunLuoPathComponent>();
	        
	        EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() {Unit = unit});
            return unit;
        }
        
        public static Unit Create(Scene scene, long id, int unitType)
        {
	        // UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
	        UnitInfo unitInfo = UnitInfo.Create();
	        switch (unitType)
	        {
		        case UnitType.Player:
		        {
			        unitInfo.UnitId = id;
			        unitInfo.ConfigId = 1001;
			        // unitInfo.Position = new float3(-10, 0, -10);
			        
			        
			        // Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
			        // unit.AddComponent<MoveComponent>();
			        // unit.Position = new float3(-10, 0, -10);

			        Unit unit = UnitFactory.Create(scene, unitInfo);
			        
			        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
			        // numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒
			        //numericComponent.Set(NumericType.AOI, 15000); // 视野15米
			        // unitComponent.Add(unit);
			        return unit;
		        }
		        default:
			        throw new Exception($"not such unit type: {unitType}");
	        }
        }
    }
}
