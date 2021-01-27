using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public void SaveFirstData()
    {
        ES3.Save<int>("Progress", 9);
        ES3.Save<bool>("EffectStatus", false);
        ES3.Save<bool>("MusicStatus", false);
    }
}
