using UnityEngine;

public abstract class SkillData3 : ScriptableObject
{
    [Header("Skill Information")]
    public string SkillName;
    public string SkillDescription;
    
    [Header("Skill Effects")]
    public GameObject effectPreFab;
    public LayerMask enemyLayer;
    
    [Header("Skill Properties")]
    public float cooldownTime = 1f;
    public float damage = 10f;
    public float range = 5f;
    
    // Abstract method for skill behavior - each skill implements its own logic
    public abstract void SkillBehavior();
}