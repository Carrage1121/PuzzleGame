
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace ET.YIUITest
{
    public partial struct YIUIVector2
    {
        public YIUIVector2(ByteBuf _buf) 
        {
            X = _buf.ReadFloat();
            Y = _buf.ReadFloat();

            PostInit();
        }

        public static YIUIVector2 DeserializeYIUIVector2(ByteBuf _buf)
        {
            return new YIUITest.YIUIVector2(_buf);
        }

        public readonly float X;
        public readonly float Y;
    

        public  void ResolveRef()
        {
            EndRef();
        }

        public override string ToString()
        {
            return "{ "
            + "x:" + X + ","
            + "y:" + Y + ","
            + "}";
        }

        partial void PostInit();
        partial void EndRef();
    }

}

