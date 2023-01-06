using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public AudioSource moumni_sound_object;
    public double moumni_duration = 15;
    public AudioSource alarm_sound_object;
    public Light light_obj;
    public double light_duration = 5;

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
                    moumni_duration -= Time.deltaTime;
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
                    light_duration -= Time.deltaTime;
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
