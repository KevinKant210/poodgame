using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponFace

{
     public struct weaponData{
        public float zoomLevel;
        public float shootSpeed;
        public float gravityForce;

        public float accuracy;

        public float bulletLifetime;

        public int magazineSize;


        public Transform shootSource;
    };
    public weaponData grabDataVals();

    public void Initialize();
    
}