namespace ET.Client
{
    [Event(SceneType.All)]
    public class Test : AEvent<Scene , ClientSceneChangeEvent>
    {
        protected override async ETTask Run(Scene scene, ClientSceneChangeEvent a)
        {
            UnityEngine.Debug.Log("is Test");
            SceneChangeHelper.SceneChangeTo(scene, "Test", 0).NoContext();
            await ETTask.CompletedTask;
        }
    }
}
