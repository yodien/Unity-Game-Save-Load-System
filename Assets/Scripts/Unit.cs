using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string unit_name;
    public int unit_level;

    public int damage;
    public int shield;
    public int speed;
    public bool is_shield_up;

    public int max_HP;
    public int cur_HP;

    private Sprite sprite;

    [SerializeField] private spaceship_data ship_data;
    [SerializeField] private enemy_data enemys_data;

    public void set_player_unit(){
        //set ship data
        this.unit_name = ship_data.get_name();
        this.unit_level = ship_data.get_level();
        this.shield = ship_data.get_shield();
        this.is_shield_up = false;
        this.max_HP = ship_data.get_max_HP();
        this.cur_HP = ship_data.get_cur_HP();
        this.damage = ship_data.get_damage();
        this.speed = ship_data.get_speed();
        this.sprite = ship_data.get_ship_img();
    }

    public void set_enemy_unit(){

        //ratios and increments to scale enemy unit to player ship
        double HP_ratio = 0.3;
        double damage_ratio = 0.5;
        int speed_inc_per_level = 5; 

        // get random enemy
        enemy new_enemy = this.enemys_data.get_enemy();

        // set enemy fields
        this.unit_name = new_enemy.get_name();
        this.unit_level = ship_data.get_level();
        this.max_HP = (int) (ship_data.get_max_HP() * HP_ratio);
        this.cur_HP = this.max_HP;
        this.damage = (int) (ship_data.get_damage() * damage_ratio);
        this.speed = ship_data.get_level() * speed_inc_per_level;
        this.sprite = new_enemy.get_image();
    }

    public Sprite get_image(){ return this.sprite;}

    public bool take_damage(int damage_taken){
        if(is_shield_up){
            if(damage_taken - shield > 0)
                cur_HP -= damage_taken - shield;
        }
        else{
            cur_HP -= damage_taken;
        }

        if(cur_HP <= 0)
            return true;
        return false;
    }
}
