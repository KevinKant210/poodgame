using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for reference look at wep 1
public class Wep_2 : MonoBehaviour,WeaponFace
{   
    public AudioSource shootSound;

    public AudioSource magSound;
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

        weaponStats.shootSound = this.shootSound;

        weaponStats.magSound = this.magSound;

        weaponStats.bulletLifetime = 5;

        weaponStats.fireRate = (float) 1.5;

        weaponStats.magazineSize = 5;

        weaponStats.accuracy = (float) .8;

        weaponStats.gravityForce = (float) 9.8;

        weaponStats.shootSource = this.shootSource;



        weaponStats.shootSpeed = 300;

        weaponStats.zoomLevel = 6;

        
    }

    
}
