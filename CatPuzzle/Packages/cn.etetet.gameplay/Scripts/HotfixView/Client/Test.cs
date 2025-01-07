namespace ET.Client
{
    [Event(SceneType.Current)]
    public class Test : AEvent<Scene , ClientSceneChangeEvent>
    {
        protected override async ETTask Run(Scene scene, ClientSceneChangeEvent a)
        {
            UnityEngine.Debug.Log("is Test");
            await SceneChangeHelper.SceneChangeTo(scene, scene.Name, scene.InstanceId);
            await ETTask.CompletedTask;
        }
    }
}
