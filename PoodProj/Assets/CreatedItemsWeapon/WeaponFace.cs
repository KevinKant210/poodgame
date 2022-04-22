using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponFace

{
    //struct defined here just since this is the WeaponFace
     public struct weaponData{

         //holder for the audio that the weapon will use when fired
        public AudioSource shootSound;

        public AudioSource magSound;

        //greater the number the faster the fire rate
        public float fireRate;
        public float zoomLevel;
        public float shootSpeed;
        public float gravityForce;

        public float accuracy;

        public float bulletLifetime;

        public int magazineSize;


        public Transform shootSource;
    };

    //Interface function that will return a weaponData struct filled with values
    public weaponData grabDataVals();

    
    //Initialize Function as a ghetto constructor for the weapons
    public void Initialize();
    
}

