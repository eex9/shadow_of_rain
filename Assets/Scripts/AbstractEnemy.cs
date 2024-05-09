using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractEnemy : MonoBehaviour
{
    public Direction direction;
    public int sightTimer;
    public float sightRange;
    protected static readonly int layerMask = 3;
    protected HeadsUpDisplay UIHandler;

    void Start() {
        UIHandler = (HeadsUpDisplay) GameObject.Find("HUD").GetComponent<HeadsUpDisplay>();
    }
    void Update()
    {
        
        CastSight();
    }

    void StartSightTimer() { }

    void CastSight()
    {
        RaycastHit2D resultHit = Physics2D.CircleCast(this.transform.position, sightRange, Vector2.zero, layerMask);
        Rigidbody2D resultRB = resultHit.rigidbody;
        if (resultRB.gameObject.GetComponent<PlayerController>() == null) return; 
        Vector3 offset = resultRB.transform.position - this.transform.position;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        
        if (angle < -45) angle = 360 + angle;
        // Debug.Log(((int)(angle + 45))/90);
        if (((int)(angle + 45))/90 == (int)this.direction) {
            PlayerController player = (PlayerController) resultRB.gameObject.GetComponent<PlayerController>();
        }
    }
}
