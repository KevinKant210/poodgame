using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_1 : MonoBehaviour,WeaponFace
{   
    
    private Transform shootSource;
    public WeaponFace.weaponData weaponStats;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    public WeaponFace.weaponData grabDataVals(){return this.weaponStats;}
    

    public void Initialize(){
        
        shootSource = this.gameObject.transform.Find("ShootSource");

        weaponStats.bulletLifetime = 5;

        weaponStats.magazineSize = 10;

        weaponStats.accuracy = 1;

        weaponStats.gravityForce = (float) 9.8;

        weaponStats.shootSource = this.shootSource;

        weaponStats.shootSpeed = 200;

        weaponStats.zoomLevel = 12;

        
    }

    
}
