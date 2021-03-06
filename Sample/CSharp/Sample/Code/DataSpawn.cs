using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Scorpio.Commons;
using Scorpio.Table;
namespace ScorpioProtoTest {
public class DataSpawn : IData {
    private bool m_IsInvalid;
    private int _ID;
    /// <summary> 测试ID 此值必须唯一 而且必须为int型() </summary>
    public int getID() { return _ID; }
    public int ID() { return _ID; }
    private int _TestInt;
    /// <summary> int类型() </summary>
    public int getTestInt() { return _TestInt; }
    private string _TestString;
    /// <summary> string类型() </summary>
    public string getTestString() { return _TestString; }
    private bool _TestBool;
    /// <summary> bool类型() </summary>
    public bool getTestBool() { return _TestBool; }
    private Int2 _TestInt2;
    /// <summary> 自定义类型 根据ExcelConfig下 table.sco文件定义的Int2解析 类型为table_后面的名字 格式为 , 隔开() </summary>
    public Int2 getTestInt2() { return _TestInt2; }
    private TestEnum _TestEnumName;
    /// <summary> 自定义枚举() </summary>
    public TestEnum getTestEnumName() { return _TestEnumName; }
    public object GetData(string key ) {
        if (key == "ID") return _ID;
        if (key == "TestInt") return _TestInt;
        if (key == "TestString") return _TestString;
        if (key == "TestBool") return _TestBool;
        if (key == "TestInt2") return _TestInt2;
        if (key == "TestEnumName") return _TestEnumName;
        return null;
    }
    public bool IsInvalid() { return m_IsInvalid; }
    private bool IsInvalid_impl() {
        if (!TableUtil.IsInvalid(this._ID)) return false;
        if (!TableUtil.IsInvalid(this._TestInt)) return false;
        if (!TableUtil.IsInvalid(this._TestString)) return false;
        if (!TableUtil.IsInvalid(this._TestBool)) return false;
        if (!TableUtil.IsInvalid(this._TestInt2)) return false;
        if (!TableUtil.IsInvalid(this._TestEnumName)) return false;
        return true;
    }
    public static DataSpawn Read(ScorpioReader reader) {
        DataSpawn ret = new DataSpawn();
        ret._ID = reader.ReadInt32();
        ret._TestInt = reader.ReadInt32();
        ret._TestString = reader.ReadString();
        ret._TestBool = reader.ReadBool();
        ret._TestInt2 = Int2.Read(reader);
        ret._TestEnumName = (TestEnum)reader.ReadInt32();
        ret.m_IsInvalid = ret.IsInvalid_impl();
        return ret;
    }
}
}