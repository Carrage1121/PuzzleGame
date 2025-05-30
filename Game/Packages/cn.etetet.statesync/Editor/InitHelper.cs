﻿using UnityEditor;
using UnityEngine;

namespace ET
{
    public static class InitHelper
    {
        [MenuItem("ET/StateSync/Init")]
        public static void Init()
        {
            HybridCLREditor.Init();
            
            EditorApplication.ExecuteMenuItem("ET/Excel/ExcelExporter");
            
            ProtoEditor.Init();
            
            LoaderEditor.Init();    
            
            AssetDatabase.Refresh();
            
            Debug.Log("Init finish!");
        }
    }
}