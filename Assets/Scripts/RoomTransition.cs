using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public AudioClip newMusic;
    public GameObject roomCamera;

    void void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag!="Player") return;
        Camera.allCameras[0].enabled = false;
        roomCamera.enabled = true;
        AudioHandler.ChangeBGM(newMusic);
    }
}