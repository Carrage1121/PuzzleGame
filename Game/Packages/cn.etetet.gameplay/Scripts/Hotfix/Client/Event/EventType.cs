using System.Numerics;

namespace ET.Client
{
    public struct ClientSceneChangeEvent
    {
        
    }

    public struct PlayerMoveEvent
    {
        public Unit unit;
        public Unity.Mathematics.float3 position;
    }
}