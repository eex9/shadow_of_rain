using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPatrolEnemy : AbstractEnemy, Pathfinding
{
    public List<GameObject> targetPoints;
    public int moveTime; //velocity=time/distance
    public int waitTime;
    int index;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        this.transform.position = targetPoints[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getNextPoint(){
        index++;
        if (index >= targetPoints.Count) {
            index = 0;
        }
        return targetPoints[index];
    }

    public Vector3 getOffset(GameObject target) {
        return target.transform.position - this.transform.position;
    }

    public void startMove() {
        target = getNextPoint();
        Vector3 offset = getOffset(target);

        /* something somethins
        need periodic movement - continuous then wait
        */
    }
}
