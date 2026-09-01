using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObject/SkillData")]
public class SkillData : ScriptableObject
{
    public string Name;
    public int UnlockLevel;
    public SkillTarget Target;
    public SkillType Type;
    public SkillAttribute Attribute;

    public List<SkillEffect> Effect;
}

public enum SkillTarget
{
    SingleEnemy,
    AllEnemy,
    Self,
    Team
}

public enum SkillType
{
    Force,
    Magic
}

public enum SkillAttribute
{
    Fire,
    Water,
    Soil,
    Air,
    Plasma,
    Data
}


