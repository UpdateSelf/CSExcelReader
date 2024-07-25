using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSExcelReader.Core;
using Player.Test;
using ClientServerLib;

public class CSReaderTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataBlockManager.I.Init(name => Resources.Load<TextAsset>($"GameConfigs/{name}").bytes);
        Debug.Log(PlayerInfos.V.Bonus[1].ListToString());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
