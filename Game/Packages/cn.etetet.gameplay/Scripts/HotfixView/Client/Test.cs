namespace ET.Client
{
    [Event(SceneType.All)]
    public class Test : AEvent<Scene , ClientSceneChangeEvent>
    {
        protected override async ETTask Run(Scene scene, ClientSceneChangeEvent a)
        {
            UnityEngine.Debug.Log("Go TestScene");
            SceneChangeHelper.SceneChangeTo(scene, "TestScene", 0).NoContext();
            await ETTask.CompletedTask;
        }
    }
}
