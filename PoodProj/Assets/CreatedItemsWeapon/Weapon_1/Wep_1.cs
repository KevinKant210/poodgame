using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_1 : MonoBehaviour,WeaponFace
{   
    //this is just an empty where the bullet spawns from (unique for each weapon)

    public AudioSource shootSound;
    private Transform shootSource;

    //struct that contains all the stats as defined in weapon face Interface
    public WeaponFace.weaponData weaponStats;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
    //return the struct for this weapon
    public WeaponFace.weaponData grabDataVals(){return this.weaponStats;}
    

    //initialize the guns stats,
    public void Initialize(){
        
        //this line finds the unique ShootSource empty child attatched to each gun
        shootSource = this.gameObject.transform.Find("ShootSource");

        weaponStats.fireRate = 1;

        weaponStats.shootSound = this.shootSound;

        weaponStats.bulletLifetime = 5;

        weaponStats.magazineSize = 10;

        weaponStats.accuracy = 1;

        weaponStats.gravityForce = (float) 9.8;

        weaponStats.shootSource = this.shootSource;

        weaponStats.shootSpeed = 200;

        weaponStats.zoomLevel = 12;


        
    }

    


    
}
