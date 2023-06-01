using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternDemo : MonoBehaviour
{
    public List<BaseSkillBehavior> _skillOwning;

    public void AddSkill(SkillID skillID)
    {
        _skillOwning ??= new List<BaseSkillBehavior>();

        //if (_skillOwning == null)
        //    _skillOwning = new List<BaseSkillBehavior>();

        //EnumUtility.GetStringType : Convert enum thành class tương ứng
        //System.Activator.CreateInstance: Tạo 1 đối tượng của class truyền vào

        _skillOwning.Add(System.Activator.CreateInstance(EnumUtility.GetStringType(skillID)) as BaseSkillBehavior);
    }

    public void OnClickActiveSkill()
    {
        ActiveSkill();
    }
    private void ActiveSkill()
    {
        if (_skillOwning != null)
            _skillOwning.ForEach(x => x.ActiveEffect());
    }
}
