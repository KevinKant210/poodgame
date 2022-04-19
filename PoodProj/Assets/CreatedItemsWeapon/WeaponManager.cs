using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{   

    //bulletPref is the preface object that we spawn the bullet from
    public GameObject bulletPref;

    private Transform shootSource;



    //holder for whatever the current weapon is
    private GameObject currWeapon;
    
    //holder for the curr weapon stats 
    private WeaponFace.weaponData currWeaponStats;

    //this holds what weapon is selected ( currently public so we can easily test all three guns)
    public int weaponNum;

    //all of these are the holders to the weapon prefabs
    public GameObject Weapon1;
    
    public GameObject Weapon2;
    public GameObject Weapon3;

    private int currMagSize;
    
    private float shootTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        //logic on start to determine which weapon to init
        if(weaponNum == 3){
            currWeapon = Instantiate(Weapon3,this.transform.position,this.transform.rotation,this.transform);
        }else if (weaponNum == 2){
            currWeapon = Instantiate(Weapon2,this.transform.position,this.transform.rotation,this.transform);
        }else{
            currWeapon = Instantiate(Weapon1,this.transform.position,this.transform.rotation,this.transform);
        }

        

        //initialize the weapon from the prefab
        currWeapon.GetComponent<WeaponFace>().Initialize();
        //get its current stats via the grabDataVals
        currWeaponStats = currWeapon.GetComponent<WeaponFace>().grabDataVals();
        //set the curr mag size
        currMagSize = currWeaponStats.magazineSize;
    }

    // Update is called once per frame
    void Update()
    {   
        if(shootTimer > 0) shootTimer -= Time.deltaTime*currWeaponStats.fireRate;
        //temporary for testing
        getInput();
    }

    //temporary function for testing
    private void getInput(){

        var mouse = Mouse.current;
        var keyboard = Keyboard.current;
        if(mouse.leftButton.wasPressedThisFrame){
            
            Shoot();
        }

        if(keyboard.rKey.wasReleasedThisFrame){
            Reload();
        }
        
        
    }

    
    //function that shoots the curretn weapon
    public void Shoot(){
        //if no bullets return
        if(currMagSize == 0 || shootTimer > 0 )return;

        shootTimer = 1;
        currMagSize--;

        //generate a bullet opject at the shoot source of the weapon
        GameObject bullet = Instantiate(bulletPref,currWeaponStats.shootSource.position, currWeaponStats.shootSource.rotation);

        //grab the bullet scrip to make sure it exsits
        ParaBullet bulletScript = bullet.GetComponent<ParaBullet>();

        //run the ghetto bullet constructor
        if(bulletScript){
            
            bulletScript.Initialize(currWeaponStats.shootSource,currWeaponStats.shootSpeed,currWeaponStats.gravityForce);
            currWeaponStats.shootSound.Play();
        }
       
        //destroy the bullet if it travels for longer then its lifetime ( never hits something)
        Destroy(bullet,currWeaponStats.bulletLifetime);
    }
    

    //reload to fill magazine
    public void Reload(){
        currMagSize = currWeaponStats.magazineSize;
    }


    /*
    void OldShoot(){
        if(magazineSize == 0 )return;
        //magazineSize--;
        GameObject bullet = Instantiate(bulletPref,shootSource.position, shootSource.rotation);

        ParaBullet bulletScript = bullet.GetComponent<ParaBullet>();

        if(bulletScript){
            bulletScript.Initialize(shootSource,shootSpeed,gravityForce);
            
        }
       

        Destroy(bullet,bulletLifetime);
    }
    */
}
