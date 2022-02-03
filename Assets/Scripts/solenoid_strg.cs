using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//button increasing solenoid strength by 250
public class solenoid_strg : MonoBehaviour
{
    public Text datatab;
    public ExternalFieldSolenoidScript field_param; 
    // Start is called before the first frame update
    void OnMouseDown(){
        field_param.strength += 250;
        datatab = datatab.GetComponent<Text>();
        datatab.text = $"Заряд/масса частиц 220 Кл/кг; ток в соленоиде: {field_param.strength}А";
    }
}