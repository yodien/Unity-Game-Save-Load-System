using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class preload_data : MonoBehaviour
{
    [SerializeField] private spaceship_data ship_data;
    [SerializeField] private shop_data item_data;
    [SerializeField] private enemy_data enemys_data;

    public GameObject health_upgrade;
    public GameObject damage_upgrade;
    public GameObject speed_upgrade;
    public GameObject shield_upgrade;

    public Sprite player_ship;

    public Sprite light_carrier;
    public Sprite fortress;
   
    // Awake called when game is launching
    void Awake()
    {
        // init ship_data
        int HP = 100;
        int speed = 5;
        int money = 100;
        Sprite ship_img = this.player_ship;
        ship_data.init(HP, speed, money, ship_img);

        //------------------------------------------------------------------------------------------
        // UPGRADES

        // Init all shop item data
        int cost_inc_per_level = 5;
        int val_inc_per_level = 10;
        item_data.init(cost_inc_per_level, val_inc_per_level);

        Sprite health_upgrade_img = health_upgrade.GetComponent<SpriteRenderer>().sprite;
        Sprite damage_upgrade_img = damage_upgrade.GetComponent<SpriteRenderer>().sprite;
        Sprite speed_upgrade_img = speed_upgrade.GetComponent<SpriteRenderer>().sprite;
        Sprite shield_upgrade_img = shield_upgrade.GetComponent<SpriteRenderer>().sprite;

        string name = "Health Upgrade";
        string type = "Health";
        int level = 1;
        int cost = 10;
        int val = 5;

        this.item_data.add_upgrade(name, type, level, cost, val, health_upgrade_img);

        name = "Damage Upgrade";
        type = "Damage";
        level = 1;
        cost = 15;
        val = 5;

        this.item_data.add_upgrade(name, type, level, cost, val, damage_upgrade_img);

        name = "Shield Upgrade";
        type = "Shield";
        level = 1;
        cost = 10;
        val = 5;

        this.item_data.add_upgrade(name, type, level, cost, val, shield_upgrade_img);

        name = "Speed Upgrade";
        type = "Speed";
        level = 1;
        cost = 5;
        val = 5;

        this.item_data.add_upgrade(name, type, level, cost, val, speed_upgrade_img);

        //----------------------------------------------------------------------------------------
        // ENEMIES

        //enemy intializations
        this.enemys_data.init();

        name = "Light Carrier";
        Sprite img = this.light_carrier;
        this.enemys_data.add_enemy(name, img);

        name = "Fortress";
        img = this.fortress;
        this.enemys_data.add_enemy(name, img);

        //--------------------------------------------------------------------------------------------


    }
}
