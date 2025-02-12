using System;
using CommandLine;
using UnityEngine;

namespace ET
{
    public class Init: MonoBehaviour
    {
        private void Start()
        {
            this.StartAsync().NoContext();
        }
		
        private async ETTask StartAsync()
        {
            DontDestroyOnLoad(gameObject);
			
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Log.Error(e.ExceptionObject.ToString());
            };

            // 命令行参数
            string[] args = "".Split(" ");
            Parser.Default.ParseArguments<Options>(args)
                    .WithNotParsed(error => throw new Exception($"命令行格式错误! {error}"))
                    .WithParsed((o)=>World.Instance.AddSingleton(o));

            //获取globalConfig
            GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
            //绑定场景名
            Options.Instance.SceneName = globalConfig.SceneName;
			
            //输出
            World.Instance.AddSingleton<Logger>().Log = new UnityLogger();
            ETTask.ExceptionHandler += Log.Error;
			
            //时间
            World.Instance.AddSingleton<TimeInfo>();
            
            //todo
            //纤程？
            World.Instance.AddSingleton<FiberManager>();

            //todo
            //创建默认包
            await World.Instance.AddSingleton<ResourcesComponent>().CreatePackageAsync("DefaultPackage", true);
            
            //CodeLoad开启游戏
            World.Instance.AddSingleton<CodeLoader>().Start().NoContext();
        }

        private void Update()
        {
            TimeInfo.Instance.Update();
            FiberManager.Instance.Update();
        }

        private void LateUpdate()
        {
            FiberManager.Instance.LateUpdate();
        }

        private void OnApplicationQuit()
        {
            World.Instance.Dispose();
        }
    }
}