using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int MaxHP;
    public int MaxST;
    public int CurrentHP;
    public int CurrentST;     //스테미나

    public int playerAtk;     //공격력
    public int playerDef;     //방어력

    public int playerMaxLv;
    public int playerCurrentLv;
    public int currentExp;
    public int needExp;



    private const int basePlayerHP = 490;
    private const int basePlayerST = 100;
    private const int basePlayerAtk = 60;
    private const int basePlayerDef = 60;       //기본 체력, 스테미나, 공격력, 방어력
    private const int improvePlayerHP = 87;
    private const int improvePlayerST = 10;
    private const int improvePlayerAtk = 3;
    private const int improvePlayerDef = 3;     //레벨이 늘어날 때마다 증가하는 체력, 스테미나, 공격력, 방어력
    //임의로 넣었기 때문에 나중에 수정해야함.




    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
        CurrentST = MaxST;
    }

    private void Update()
    {
        CheckPlayerExp();
    }




    private void CheckPlayerExp()
    {
        needExp = playerCurrentLv * 100;        // 레벨업에 필요한 경험치 ( 나중에 조정해야함 )


        if (currentExp >= needExp && playerCurrentLv < playerMaxLv)
        {
            playerCurrentLv++;
            currentExp -= needExp;
            ImprovePlayerStats();
        }



    }

    private void ImprovePlayerStats()
    {
        MaxHP = basePlayerHP + improvePlayerHP * (playerCurrentLv - 1);
        MaxST = basePlayerST + improvePlayerST * (playerCurrentLv - 1);
        playerAtk = basePlayerAtk + improvePlayerAtk * (playerCurrentLv - 1);
        playerDef = basePlayerDef + improvePlayerDef * (playerCurrentLv - 1);
    }



    public void PlayerGetDamage(int _enemyAtk)        // 적이 공격을 맞추면 적의 공격력을 인수로 주고 이 함수를 호출
    {
        int damage;
        if (_enemyAtk <= playerDef)
            damage = 1;
        else
            damage = _enemyAtk - playerDef + Random.Range(-(_enemyAtk - playerDef) / 10, (_enemyAtk - playerDef) / 10);

        //10%의 난수를 넣어 항상 같은 데미지가 나오지 않도록 함


        CurrentHP -= damage;
        Debug.Log(damage + "피해를 입었습니다.");   // 테스트용


        if (CurrentHP <= 0)
        {
            Debug.Log("플레이어 죽음");
            // Object Destroy
        }

    }

}
