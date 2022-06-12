using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float slowdownTime = 10f;
    private float slowMotionTime = 0.1f;
    private GameObject skill;
    [SerializeField] private GameObject button;
   
    private void Start()
    {
        skill = GameObject.Find("Skill");
        skill.GetComponent<ChooseSkill>().enebleSlowMotion += TurnOnSlowMotion;
    }

    private void TurnOnSlowMotion()
    {
        StartCoroutine(DoSlowMotion());
    }
    IEnumerator DoSlowMotion()
    {
        Time.timeScale = slowMotionTime;
        button.SetActive(false);
        yield return new WaitForSecondsRealtime(slowdownTime);
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(15f);
        button.SetActive(true);
    }
}
