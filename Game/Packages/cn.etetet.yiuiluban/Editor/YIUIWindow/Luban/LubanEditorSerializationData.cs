using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using YIUIFramework;

namespace YIUILuban.Editor
{
    public class LubanEditorSerializationData
    {
        [ShowInInspector]
        [OdinSerialize]
        [LabelText("根节点显示所有配置")]
        [OnValueChanged("OnRootShowAllConfigChanged")]
        public bool RootShowAllConfig = true; //根节点就显示所有配置 否则降低到子节点 优点: 少跳一次选择 打开即用 缺点: 以后非常多文件后可能会很慢 优化: 可以后根据需求在调整 前期可以先默认显示所有

        private void OnRootShowAllConfigChanged()
        {
            UnityTipsHelper.Show($"修改了根节点显示所有配置, 下一次重新打开窗口生效。");
        }

        [HideInInspector]
        [OdinSerialize]
        public Dictionary<string, LubanPackageEditorData> LubanEditorPackageSettings = new();

        [HideInInspector]
        [OdinSerialize]
        public Dictionary<string, Dictionary<string, LubanConfigEditorData>> LubanEditorConfigSettings = new();

        public const string LubanEditorPackageSettingsPath = "Assets/../Packages/cn.etetet.yiuilubangen/Assets/Editor/LubanEditorSerializationDataSettings.txt";

        public LubanPackageEditorData GetLubanEditorPackageSettings(string packageName)
        {
            if (!LubanEditorPackageSettings.TryGetValue(packageName, out var packageData))
            {
                packageData = new LubanPackageEditorData();
                LubanEditorPackageSettings.Add(packageName, packageData);
            }

            packageData.PackageName = packageName;
            return packageData;
        }

        public LubanConfigEditorData GetLubanConfigEditorData(string configName, string path)
        {
            var packageName = UIOperationHelper.GetETPackagesName(path, false);

            if (!LubanEditorConfigSettings.TryGetValue(packageName, out var configData))
            {
                configData = new Dictionary<string, LubanConfigEditorData>();
                LubanEditorConfigSettings.Add(packageName, configData);
            }

            if (!configData.TryGetValue(configName, out var configEditorData))
            {
                configEditorData = new LubanConfigEditorData();
                configData.Add(configName, configEditorData);
            }

            configEditorData.Name        = configName;
            configEditorData.Path        = path;
            configEditorData.PackageName = packageName;

            return configEditorData;
        }
    }
}