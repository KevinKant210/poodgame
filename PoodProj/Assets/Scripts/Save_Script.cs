using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Script : MonoBehaviour
{
    
    // Start is called before the first frame update
   public void saveLevel(){
       PlayerPrefs.SetInt("savedLevel", PlayerPrefs.GetInt("currLevel") + 1);
       Debug.Log(PlayerPrefs.GetInt("savedLevel"));
   }
}
