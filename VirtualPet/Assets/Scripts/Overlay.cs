using UnityEngine;

public class Overlay : MonoBehaviour
{
    public AudioSource brickSfx;
    public AudioSource showerSfx;
    
    public void PlayBrickSfx()
    {
        brickSfx.Play();
    }
    public void PlayShowerSfx()
    {
        showerSfx.Play();
    }
}
