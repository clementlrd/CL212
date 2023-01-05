using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public AudioSource moumni_sound_object;
    public int moumni_duration = 3000;
    public AudioSource alarm_sound_object;
    public Light light_obj;
    public int light_duration = 300;

    private string step = "start";

    // Start is called before the first frame update
    void Start()
    {
        moumni_sound_object.Play();
    }

    void Update() {
        switch(step) {
            case "start":
                if (moumni_duration > 0) {
                    moumni_duration--;
                    
                } else {
                    step = "alarm";
                }
                break;
            case "alarm":
                moumni_sound_object.volume = 0;
                alarm_sound_object.Play();
                light_obj.color = Color.red;
                step = "light";
                break;
            case "light":
                if (light_duration > 0) {
                    light_duration--;
                } else {
                    step = "end";
                }
                break;
            case "end":
                light_obj.color = Color.white;
                break;
            default:
                break;
        }
        
    }
}
