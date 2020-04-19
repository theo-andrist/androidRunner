using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Skills
{
    skill_DoubleJump,
    skill_PlayerSpeed,
    skill_GrenadeSpeed,
}

public class Skill_Behavior : MonoBehaviour
{
    public Skills thisSkill = Skills.skill_DoubleJump;
    public SkillTree_Behavior tree;
    public bool isPurchased = false;

    private Skill_Behavior requiredSkill;
    private Text textSkill;

    void Start()
    {
        textSkill = GetComponentInChildren<Text>();

        if (thisSkill.Equals(Skills.skill_DoubleJump)) { requiredSkill = tree.playerSpeed; requiredSkill = tree.grenadeSpeed; }

    }

    public void RankUp()
    {
        if (tree.skillPoints > 0 && !isPurchased)
        {
            if (thisSkill.Equals(Skills.skill_GrenadeSpeed))
            {
                tree.skillPoints -= 1;
                isPurchased = true;
                textSkill.text = "Purchased";
                GrenadeSpeed();
            }
            if (thisSkill.Equals(Skills.skill_PlayerSpeed))
            {
                tree.skillPoints -= 1;
                isPurchased = true;
                textSkill.text = "Purchased";
                PLayerSpeed();
            }
            else if (requiredSkill.isPurchased)
            {
                tree.skillPoints -= 1;
                isPurchased = true;
                textSkill.text = "Purchased";
                if (thisSkill.Equals(Skills.skill_DoubleJump)) { DoubleJump(); }
            }
        }
    }

    private void GrenadeSpeed()
    {

    }

    private void PLayerSpeed()
    {

    }

    private void DoubleJump()
    {

    }
}
