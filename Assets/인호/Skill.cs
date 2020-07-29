using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private BallScript theBall;
    private Moving thePlayer;

    public bool canUseSizeUp = true;   // 쿨타임 동안에는 flase 아니면 true
    public bool unlockSizeUp = false;  // 스테이지 2부터 unlock 됨
    public float duration;        // 지속시간
    public float sizeUp;          // 커지는 배수
    public float sizeUpCoolTime;        // 쿨타임 시간


    private int sizeUpSkillCount = 0;
    public int sizeUpSkillLv = 1;
    public int neededStageNumberForSkillSizeUp = 2;

    public int currentStageNumber;         // 스킬 사용횟수, 스킬 레벨, 현재 스테이지 단계. 수정해야함.

    public int maxSkillLv = 10;

    private void Start()
    {
        theBall = FindObjectOfType<BallScript>();
        thePlayer = FindObjectOfType<Moving>();
        ImproveSizeUpSkill(sizeUpSkillLv);
    }






    public void Skill_SizeUp()
    {
        sizeUpSkillCount++;

        StartCoroutine(SizeUp());
        CheckSkillExp(ref sizeUpSkillLv, ref sizeUpSkillCount);

    }

    IEnumerator SizeUp()
    {
        canUseSizeUp = false;
        float distanceBallPlayer = 4f;
        Vector3 tempSize = theBall.transform.localScale;
        float alpha = (theBall.transform.localPosition.x - distanceBallPlayer) / tempSize.x;

        theBall.transform.localScale = new Vector3(tempSize.x * sizeUp, tempSize.y * sizeUp, tempSize.z);
        theBall.transform.localPosition = new Vector3(distanceBallPlayer + tempSize.x * sizeUp * alpha, 0, theBall.transform.localPosition.z);

        yield return new WaitForSeconds(duration);
        theBall.transform.localScale = tempSize;



        yield return new WaitForSeconds(sizeUpCoolTime);
        canUseSizeUp = true;
    }

    private void CheckSkillExp(ref int currentLv, ref int currentCount)
    {
        int needExp;      // 다음 레벨로 올라가기 위해 필요한 경험치
        needExp = currentLv * 500;     //1Lv 에서 2Lv가 되기 위해서는 스킬을 500번 사용해야함

        if (currentCount >= needExp && currentLv < maxSkillLv)
        {
            currentCount -= needExp;
            currentLv++;
            ImproveSizeUpSkill(currentLv);
        }

    }

    private void ImproveSizeUpSkill(int _currentLv)
    {
        if ((_currentLv - 1) % 3 == 0)      // 1, 4, 7, 10레벨일 경우에만 실행
        {
            sizeUp = (float)((_currentLv - 1) / 3 + 3) * 0.5f;

            // 플레이어 공격력 증가 (플레이어 스탯 구현 후에 만들 예정)
        }

        duration = 3 + _currentLv * 0.5f;
        sizeUpCoolTime = 10 - _currentLv * 0.5f;

    }






}
