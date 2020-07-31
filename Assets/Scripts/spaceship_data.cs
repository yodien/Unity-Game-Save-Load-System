using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "spaceship_data", menuName = "spaceship_data")]
public class spaceship_data : ScriptableObject
{
    public Ship ship = null;
    public Sprite ship_img;
    public int money;
    public int consum_count = 0;
    public int weapon_count = 0;

    public void init(int HP, int speed, int money, Sprite img){
        this.ship = new Ship(HP, speed);
        this.ship_img = img;
        this.money = 100;
    }
    /// //////
    public void init2(int HP, int HP_cur, int speed, int shield, int level, int cur_exp, int max_exp, int damage, string name, int money)
    {
        this.ship = new Ship(HP, HP_cur, speed, shield, level, cur_exp, max_exp, damage, name);
        this.money = money;
    }

    public void init3(int HP, int speed, int money, string name)
    {
        this.ship = new Ship(HP, speed);
        this.ship.name = name;
        this.money = money;
    }
    /// /////////////////////

    // needed setters
    public void set_ship_health(int max_HP, int cur_HP){ this.ship.set_HP(max_HP, cur_HP);}

    public void set_level(int level){ this.ship.set_level(level);}

    // neeeded getters
    public Sprite get_ship_img(){ return this.ship_img;}

    public int get_level(){ return this.ship.get_level();}

    public int get_max_HP(){ return this.ship.get_max_HP();}

    public int get_cur_HP(){ return this.ship.get_cur_HP();}

    public void set_shield(int shield){ this.ship.set_shield(shield);}

    public int get_shield(){ return this.ship.get_shield();}

    public string get_name(){ return this.ship.get_name();}

    public int get_money(){ return money;}

    public int get_speed(){return this.ship.get_speed();}

    public int get_damage(){ return this.ship.get_damage();}

    //neeeded updates
    public void update_money(int update_value){
        this.money += update_value;

        if(this.money < 0)
            this.money = 0;
    }

    public void update_HP(int HP_inc){ this.ship.update_HP(HP_inc);}

    public void update_damage(int damage_inc){ this.ship.update_damage(damage_inc);}

    public void update_shield(int shield_inc){ this.ship.update_shield(shield_inc);}

    public void update_speed(int speed_inc){ this.ship.update_speed(speed_inc);}

    public void update_exp(int exp){ this.ship.update_exp(exp);}

    

}

[System.Serializable]
public class Ship{
    public string name;
    public int max_HP;
    public int cur_HP;
    public int speed;
    public int level;
    public int shield;
    public bool is_shield_up;
    public int cur_exp;
    public int max_exp;
    public int damage;

    public Ship(int HP, int speed){
        this.max_HP = HP;
        this.cur_HP = HP;
        this.speed = speed;
        this.shield = 5;
        this.is_shield_up = false;

        this.level = 1;
        this.cur_exp = 0;
        this.max_exp = 100;
        this.damage = 10;
        this.name = "Galactis";
    }
    ///////
    public Ship(int HP, int HP_cur, int speed, int shield, int level, int cur_exp, int max_exp, int damage, string name)
    {
        this.max_HP = HP;
        this.cur_HP = HP_cur;
        this.speed = speed;
        this.shield = shield;
        this.is_shield_up = false;

        this.level = level;
        this.cur_exp = cur_exp;
        this.max_exp = max_exp;
        this.damage = damage;
        this.name = name;
    }
    ////////////////////////////////////////////

    public void set_HP(int max, int cur){
        this.max_HP = max;
        this.cur_HP = cur;
    }

    public void set_level(int level){ this.level = level;}

    public int get_level(){ return this.level;}

    public void set_shield(int shield){ this.shield = shield;}

    public int get_shield(){ return this.shield;}

    public int get_max_HP(){ return this.max_HP;}

    public int get_cur_HP(){ return this.cur_HP;}

    public string get_name(){ return this.name;}

    public int get_damage(){ return this.damage;}

    public int get_speed(){return this.speed;}

    public void update_HP(int HP_inc){ 
        this.max_HP += HP_inc;
        this.cur_HP += HP_inc;
    }

    public void update_damage(int damage_inc){ this.damage += damage_inc;}

    public void update_speed(int speed_inc){ this.speed += speed_inc;}

    public void update_shield(int shield_inc){ this.shield += shield_inc;}

    public void update_exp(int exp){
        if(exp <= 0)
            return;

        // level up or increase exp
        if(exp + cur_exp >= max_exp){
            level += 1;
            max_exp += 20;
            cur_exp = (exp + cur_exp) % max_exp; 
        }
        else{
            cur_exp += exp;
        }
    }

}
