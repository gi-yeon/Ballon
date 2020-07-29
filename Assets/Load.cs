using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    private Moving thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Moving>();
        if (ES3.KeyExists("playerPosition") && ES3.KeyExists("btn"))
        {
            if (ES3.Load<BTNType>("btn") != BTNType.load)
                return;

            thePlayer.transform.position = ES3.Load<Vector3>("playerPosition");
        }
    }
}
