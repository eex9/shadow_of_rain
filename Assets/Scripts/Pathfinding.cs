using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Pathfinding
{
    GameObject getNextPoint();
    Vector3 getOffset(GameObject target);
    void startMove();
}
