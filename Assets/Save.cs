using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private Moving thePlayer;
    private Vector3 playerPos;
    void Start()
    {
        thePlayer = FindObjectOfType<Moving>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SaveData();
            Debug.Log("저장되었습니다.");
        }
    }

    void SaveData()
    {
        playerPos = thePlayer.transform.position;
        ES3.Save<Vector3>("playerPosition", playerPos);
    }
}
