using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree_Behavior : MonoBehaviour
{
    private bool SkillTreeBool = false;
    public int skillPoints = 0;
    public GameObject skillTreeOBJ;
    public Skill_Behavior doubleJump, playerSpeed, grenadeSpeed;

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SkillTree();
        }

        if (skillTreeOBJ)
        {
            skillTreeOBJ.SetActive(true);
        }
        else { skillTreeOBJ.SetActive(false); }

    }

    public void SkillTree()
    {
        SkillTreeBool = !SkillTreeBool;
    }
}
