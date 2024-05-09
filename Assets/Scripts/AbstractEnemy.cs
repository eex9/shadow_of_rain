using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractEnemy : MonoBehaviour
{
    public Direction direction;
    public int sightTimer;
    public float sightRange;
    protected static readonly int layerMask = 3;

    void Update()
    {
        // if (Input.GetKeyDown("return"))
        // {
            CastSight();
        // }
    }

    void StartSightTimer() { }

    void CastSight()
    {
        RaycastHit2D resultHit = Physics2D.CircleCast(this.transform.position, sightRange, Vector2.zero, layerMask);
        Rigidbody2D resultRB = resultRB.GetComponent<Rigidbody>();
        if (resultHit.gameObject.getComponent<PlayerController>() == null) return; 
        Vector3 offset = resultRB.transform.position - this.transform.position;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        
        if (angle < -45) angle = 360 + angle;
        // Debug.Log(((int)(angle + 45))/90);
        if (((int)(angle + 45))/90 == (int)this.direction) {
            (PlayerController) player = resultRB.gameObject.getComponent<PlayerController>();
            player.Kill();
        }
    }
}
