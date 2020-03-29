using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class StageView : MonoBehaviour
{
    [SerializeField] GameObject monsterViewPrefab;
    [SerializeField] GameObject monster;


    bool isThereMonster; //monster存在フラグ。待機時間を設ける為にフラグを持つ



    public void SpawnMonster()
    {
        monster = Instantiate(monsterViewPrefab);
        monster.transform.SetParent(transform, false);
        isThereMonster = true;
        if (isThereMonster == true)
        {
            Debug.Log("Success");
        }

    }

}