
namespace ET.Client
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = currentScene.Root().GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        unitComponent.Add(unit);
	         
	        unit.Position = unitInfo.Position;
	        unit.Forward = unitInfo.Forward;
	        
	        //NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
			// foreach (var kv in unitInfo.KV)
			// {
			// 	numericComponent.Set(kv.Key, kv.Value);
			// }
			
	        unit.AddComponent<ObjectWait>();
	        // unit.AddComponent<OperaComponent>();
	        
	        EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() {Unit = unit});
            return unit;
        }
        
        public static Unit Create(Scene scene, long id, int unitType)
        {
	        // UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
	        UnitInfo unitInfo = UnitInfo.Create();
	        Unit unit = null;
	        switch (unitType)
	        {
		        case UnitType.Player:
		        {
			        unitInfo.UnitId = id;
			        unitInfo.ConfigId = 1001;
			        unitInfo.KV.Add(NumericType.Speed , 6);
			        
			        unit = UnitFactory.Create(scene, unitInfo);

			        unit.AddComponent<MoveComponent>();
			        unit.AddComponent<NumericComponent>();
			        break;
		        }
	        }
	        return unit;
        }
    }
}
