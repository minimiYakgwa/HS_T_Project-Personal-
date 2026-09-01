using UnityEngine;

[CreateAssetMenu(fileName = "CharData", menuName = "ScriptableObject/CharData")]
public class CharacterData : ScriptableObject
{
    public string CharName;
    public int DefaultLevel;
    public int MaxHp;
    public DefaultStat DefaultStat;
    public Attribute Attribute;
}

// 캐릭터 기본 스탯 구조체
[System.Serializable]
public struct DefaultStat
{
    public int Power;
    public int Spell;
    public int Durability;
    public int Speed;
}

// 캐릭터 기본 속성 구조체
[System.Serializable]
public struct Attribute
{
    public AttributeStat Fire;
    public AttributeStat Water;
    public AttributeStat Soil;
    public AttributeStat Air;
    public AttributeStat Plasma;
    public AttributeStat Data;
}

// 캐릭터 기본 속성이 약점인지, 저항인지, 보통인지 표시하는 열거형 데이터
[System.Serializable]
public enum AttributeStat
{
    Normal,
    Resist,
    Week,
}



