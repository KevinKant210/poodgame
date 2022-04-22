using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{   

    //bulletPref is the preface object that we spawn the bullet from

    public Animator animator;
    public GameObject bulletPref;

    private Transform shootSource;



    //holder for whatever the current weapon is
    private GameObject currWeapon;
    
    //holder for the curr weapon stats 
    private WeaponFace.weaponData currWeaponStats;

    //this holds what weapon is selected ( currently public so we can easily test all three guns)
    private int weaponNum;

    //all of these are the holders to the weapon prefabs
    public GameObject Weapon1;
    
    public GameObject Weapon2;
    
    private Vector3 wep2Offset = new Vector3((float) 0,(float) -0.05,(float) -0.2);
    public GameObject Weapon3;

    private Vector3 wep3Offset = new Vector3((float) 0.02,(float) -0.243,(float) 0.1);
    private int currMagSize;
    
    private float shootTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        weaponNum = PlayerPrefs.GetInt("currWeapon") + 1;
        //logic on start to determine which weapon to init
        if(weaponNum == 3){
            currWeapon = Instantiate(Weapon3,this.transform.position + wep3Offset,this.transform.rotation,this.transform);
        }else if (weaponNum == 2){
            currWeapon = Instantiate(Weapon2,wep2Offset + this.transform.position,this.transform.rotation,this.transform);
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

    public void OnZoomInput(float zoomInput)
    {
        
        //sets the FOV to the default max and then checks if the zoom button is pressed
        //if the zoom button is pressed, then it sets the FOV to the zoom FOV
        if(zoomInput == 1){
            animator.SetBool("isScoped",true);
            StartCoroutine(onScoped());
            Debug.Log("True");
        }else{
            
            Render();
            animator.SetBool("isScoped",false);
            
            Debug.Log("False");
        }
        
    }

    IEnumerator onScoped(){
        yield return new WaitForSeconds(.15f);
        
        unRender();
        
    }

    private void unRender(){
        
        MeshRenderer[] render = currWeapon.GetComponentsInChildren<MeshRenderer>();

        foreach(MeshRenderer mesh in render){
            mesh.enabled = false;
        }
        
    }

    private void Render(){
        MeshRenderer[] render = currWeapon.GetComponentsInChildren<MeshRenderer>();

        foreach(MeshRenderer mesh in render){
            mesh.enabled = true;
        }
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
