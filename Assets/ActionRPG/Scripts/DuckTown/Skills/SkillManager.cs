using UnityEngine;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    [Header("Available Skills")]
    public List<SkillData3> availableSkills = new List<SkillData3>();
    
    private Dictionary<SkillData3, float> skillCooldowns = new Dictionary<SkillData3, float>();
    
    private void Update()
    {
        UpdateCooldowns();
    }
    
    private void UpdateCooldowns()
    {
        var keys = new List<SkillData3>(skillCooldowns.Keys);
        foreach (var skill in keys)
        {
            if (skillCooldowns[skill] > 0)
            {
                skillCooldowns[skill] -= Time.deltaTime;
                if (skillCooldowns[skill] < 0)
                    skillCooldowns[skill] = 0;
            }
        }
    }
    
    public bool TryUseSkill(SkillData3 skill)
    {
        if (!CanUseSkill(skill)) return false;
        
        skill.SkillBehavior();
        SetCooldown(skill);
        return true;
    }
    
    public bool CanUseSkill(SkillData3 skill)
    {
        if (!availableSkills.Contains(skill)) return false;
        if (!skillCooldowns.ContainsKey(skill)) return true;
        return skillCooldowns[skill] <= 0;
    }
    
    private void SetCooldown(SkillData3 skill)
    {
        skillCooldowns[skill] = skill.cooldownTime;
    }
    
    public float GetCooldownRemaining(SkillData3 skill)
    {
        if (!skillCooldowns.ContainsKey(skill)) return 0;
        return skillCooldowns[skill];
    }
}