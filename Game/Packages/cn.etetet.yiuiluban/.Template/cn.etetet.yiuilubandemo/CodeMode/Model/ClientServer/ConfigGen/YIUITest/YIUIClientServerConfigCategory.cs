
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using System.Collections.Generic;

namespace ET.YIUITest
{

    [Config]
    public partial class YIUIClientServerConfigCategory : Singleton<YIUIClientServerConfigCategory>, ILubanConfig
    {
        private readonly Dictionary<int, YIUITest.YIUIClientServerConfig> _dataMap;
        private readonly List<YIUITest.YIUIClientServerConfig> _dataList;
        
        public YIUIClientServerConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, YIUITest.YIUIClientServerConfig>();
            _dataList = new List<YIUITest.YIUIClientServerConfig>();
            
            for(int n = _buf.ReadSize() ; n > 0 ; --n)
            {
                YIUITest.YIUIClientServerConfig _v;
                _v = YIUITest.YIUIClientServerConfig.DeserializeYIUIClientServerConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }
            EndInit();
        }

        public Dictionary<int, YIUITest.YIUIClientServerConfig> GetAll() => _dataMap;
        public Dictionary<int, YIUITest.YIUIClientServerConfig> DataMap => _dataMap;
        public List<YIUITest.YIUIClientServerConfig> DataList => _dataList;

        public YIUITest.YIUIClientServerConfig GetOrDefault(int key) => _dataMap.GetValueOrDefault(key);

        public YIUITest.YIUIClientServerConfig Get(int key)
        {
            if (_dataMap.TryGetValue(key,out var v))
            {
                return v;
            }
            LubanLog.Error(this,key);
            return default;
        }

        public void ResolveRef()
        {
            foreach(var _v in _dataList)
            {
                _v.ResolveRef();
            }
            EndRef();
        }


        partial void EndRef();
    }

}

