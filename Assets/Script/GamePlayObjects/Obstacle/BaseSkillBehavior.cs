using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Behavior base
public class BaseSkillBehavior
{
    public virtual SkillID ID => SkillID.ONE;

    //Custom this function in children
    public virtual void ActiveEffect()
    {
    }
}

public enum SkillID
{
    [Type(typeof(Level1))]
    ONE,
    [Type(typeof(Level2))]
    TWO
}


public enum NewID
{
    ONE,
    TWO
}