using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : EnemyBase
{
    private void start()
    {
        this.maxHp = 100f;
        this.currentHp = 100f;
        this.damage = 5f;
    }
}
