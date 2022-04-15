using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{   

    
    public GameObject bulletPref;
    private Transform shootSource;

    private GameObject currWeapon;
    

    private WeaponFace.weaponData currWeaponStats;
    public int weaponNum;

    public GameObject Weapon1;
    
    public GameObject Weapon2;
    public GameObject Weapon3;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        if(weaponNum == 3){
            currWeapon = Instantiate(Weapon3,this.transform.position,this.transform.rotation,this.transform);
        }else if (weaponNum == 2){
            currWeapon = Instantiate(Weapon2,this.transform.position,this.transform.rotation,this.transform);
        }else{
            currWeapon = Instantiate(Weapon1,this.transform.position,this.transform.rotation,this.transform);
        }

        

        
        currWeapon.GetComponent<WeaponFace>().Initialize();

        currWeaponStats = currWeapon.GetComponent<WeaponFace>().grabDataVals();
        Debug.Log(currWeaponStats.shootSource);

    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void getInput(){

        var mouse = Mouse.current;
        if(mouse.leftButton.wasReleasedThisFrame){
            Debug.Log("Shot!");
            Shoot();
        }
        
    }

    
    
    void Shoot(){
        if(currWeaponStats.magazineSize == 0 )return;
        currWeaponStats.magazineSize--;
        GameObject bullet = Instantiate(bulletPref,currWeaponStats.shootSource.position, currWeaponStats.shootSource.rotation);

        ParaBullet bulletScript = bullet.GetComponent<ParaBullet>();

        if(bulletScript){
            bulletScript.Initialize(currWeaponStats.shootSource,currWeaponStats.shootSpeed,currWeaponStats.gravityForce);
            
        }
       

        Destroy(bullet,currWeaponStats.bulletLifetime);
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
