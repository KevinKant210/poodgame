using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stall : MonoBehaviour
{   

    public Button Button;
    // Start is called before the first frame update
    void Start()
    {
        stallButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator stallButton(){
        Button.interactable = false;
        yield return new WaitForSeconds(1f);
        Button.interactable = true;
    }
}
