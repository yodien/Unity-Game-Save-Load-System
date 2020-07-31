using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battle_HUB : MonoBehaviour
{
    public Text name_text;
    public Text level_text;

    public Slider HP_slider;

    public void set_HUB(Unit unit){
        name_text.text = unit.unit_name;
        level_text.text = "level " + unit.unit_level;
        HP_slider.maxValue = unit.max_HP;
        HP_slider.value = unit.cur_HP;
    }

    public void set_HP(int HP){
        HP_slider.value = HP;
    }
}
