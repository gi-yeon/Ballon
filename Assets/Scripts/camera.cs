using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  // 맵 이동할때 케릭터가 파괴하는걸 막는다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
