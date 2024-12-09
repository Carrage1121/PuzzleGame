using System;

namespace ET
{
    public struct EntryEvent1
    {
    }   
    
    public struct EntryEvent2
    {
    } 
    
    public struct EntryEvent3
    {
    }
    
    public static class Entry
    {
        public static void Init()
        {
            
        }
        
        public static void Start()
        {
            StartAsync().NoContext();
        }
        
        private static async ETTask StartAsync()
        {
            //todo
            //根据操作系统调整时间精度？
            WinPeriod.Init();

            // 注册Mongo type
            MongoRegister.Init();
            
            //MemoryPackage注册
            MemoryPackRegister.Init();
            
            // 注册Entity序列化器
            EntitySerializeRegister.Init();

            World.Instance.AddSingleton<SceneTypeSingleton, Type>(typeof(SceneType));
            //对象池
            World.Instance.AddSingleton<ObjectPool>();
            //id生成 所有的id唯一
            World.Instance.AddSingleton<IdGenerater>();
            
            //todo
            //网络相关？
            World.Instance.AddSingleton<OpcodeType>();
            
            //todo
            //消息队列？
            World.Instance.AddSingleton<MessageQueue>();
            
            //todo
            //网络相关？
            World.Instance.AddSingleton<NetServices>();
            
            //todo
            LogMsg logMsg = World.Instance.AddSingleton<LogMsg>();
            logMsg.AddIgnore(LoginOuter.C2G_Ping);
            logMsg.AddIgnore(LoginOuter.G2C_Ping);
            
            // 创建需要reload的code singleton
            CodeTypes.Instance.CodeProcess();
            
            await World.Instance.AddSingleton<ConfigLoader>().LoadAsync();
            
            await FiberManager.Instance.Create(SchedulerType.Main, SceneType.Main, 0, SceneType.Main, "");
        }
    }
}