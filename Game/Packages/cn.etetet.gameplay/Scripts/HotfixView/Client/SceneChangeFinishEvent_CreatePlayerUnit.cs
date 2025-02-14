
namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreatePlayerUnit : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            // Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            // unitComponent.Add(unit);
            Unit playerUnit = UnitFactory.Create(scene, 0, UnitType.Player);
            // unitComponent.Add(playerUnit);
            await ETTask.CompletedTask;
        }
    }
}
