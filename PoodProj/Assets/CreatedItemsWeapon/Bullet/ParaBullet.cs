using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaBullet : MonoBehaviour
{   
    private float speed;
    private float gravity;
    private Vector3 startPosition;
    private Vector3 startForward;
    
    private bool isInit = false;

    private float startTime = -1;
    // Start is called before the first frame update
    public void Initialize(Transform startPoint, float speed, float gravity){

        startPosition = startPoint.position;
        startForward = startPoint.forward.normalized;
        this.speed = speed;
        this.gravity = gravity;
        isInit = true;


    }

    private void FixedUpdated(){

        if (!isInit)return;

        if(startTime < 0)startTime = Time.time;

        RaycastHit hit;
        float currentTime = Time.time - startTime;
        float nextTime = currentTime + Time.fixedDeltaTime;

        Vector3 currentPoint = FindPointOnParab(currentTime);
        Vector3 nextPoint = FindPointOnParab(nextTime);

        if(RayBetweenPoints(currentPoint,nextPoint,out hit)){
            Destroy(gameObject);
        }

    }

    private void Update(){
        FixedUpdated();
        if(!isInit || startTime < 0)return;
        
        
        float currentTime = Time.time - startTime;
        
        Vector3 currentPoint = FindPointOnParab(currentTime);
        transform.position = currentPoint;
        
        
    }

    private Vector3 FindPointOnParab(float time){
        Vector3 point = startPosition + (startForward * speed * time);
        Vector3 gravityVec = Vector3.down * gravity * time * time;

        return point+gravityVec;
    }

    private bool RayBetweenPoints(Vector3 startPoint, Vector3 endPoint, out RaycastHit hit){

        return Physics.Raycast(startPoint,endPoint - startPoint, out hit, (endPoint-startPoint).magnitude);
    }

}
