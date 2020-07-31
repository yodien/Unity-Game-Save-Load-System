using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shop_controller : MonoBehaviour
{
    [SerializeField] private shop_data data;
    [SerializeField] private GameObject shop_item_prefab;
    [SerializeField] private Transform shop_container;
    [SerializeField] private spaceship_data ship_data;

    private int cost_inc;
    private int val_inc;
    private string upgrade_type;
    private string consum_type;

    
    // Start is called before the first frame update
    void Start()
    {

        // set player money UI text
        GameObject.Find("MoneyText").GetComponent<Text>().text = "$ " + this.ship_data.get_money(); 

        this.cost_inc = this.data.get_cost_inc();
        this.val_inc = this.data.get_val_inc();

        //populate shop
        populate_shop();
    }

    private void populate_shop(){

        // Scale items to current player level
        int lvl_change = this.ship_data.get_level() - this.data.get_level_of_items();

        this.data.inc_upgrades(lvl_change, lvl_change * this.cost_inc);

        

        // get upgrades
        List<upgrade> upgrades = this.data.get_upgrades();

        // Set upgrade type values for purchase later on
        this.upgrade_type = "Upgrade";

        //populate shop with items
        for(int i = 0; i < upgrades.Count; i++){
            GameObject shop_item = Instantiate(this.shop_item_prefab, this.shop_container);

            shop_item.transform.GetChild(0).GetComponent<Text>().text = upgrades[i].get_name();
            shop_item.transform.GetChild(1).GetComponent<Text>().text = "$ " + upgrades[i].get_cost();
            shop_item.transform.GetChild(2).GetComponent<Text>().text = "Lvl: " + upgrades[i].get_level();
            shop_item.transform.GetChild(3).GetComponent<Image>().sprite = upgrades[i].get_img();
            


            // money requirements to buy item
            if(upgrades[i].get_cost() > this.ship_data.get_money())
                shop_item.gameObject.GetComponent<Button>().interactable = false;

            shop_item.transform.GetChild(5).GetComponent<Text>().text = this.upgrade_type;
            Button BuyButton = shop_item.GetComponent<Button>();
            BuyButton.onClick.AddListener(() => on_buy_button(shop_item));

        }
        
    }


    // logic for valid purchase
    public void on_buy_button(GameObject shop_item){
        string name = shop_item.transform.GetChild(0).GetComponent<Text>().text;
        string type = shop_item.transform.GetChild(5).GetComponent<Text>().text;

        if(type == this.upgrade_type){
            upgrade upr = this.data.get_upgrade(name);
            int cost = upr.get_cost();

            // upgrade health
            if(upr.get_type() == "Health"){
                this.ship_data.update_HP(upr.get_val());
                wrap_up(shop_item, cost);
            }

            //upgrade damage
            else if(upr.get_type() == "Damage"){
                this.ship_data.update_damage(upr.get_val());
                wrap_up(shop_item, cost);
            }

            //upgrade speed
            else if(upr.get_type() == "Speed"){
                this.ship_data.update_speed(upr.get_val());
                wrap_up(shop_item, cost);
            }

            //upgrade shield
            else if(upr.get_type() == "Shield"){
                this.ship_data.update_shield(upr.get_val());
                wrap_up(shop_item, cost);
            }
            
        }
    }

    // wrap up function after item is purchased
    private void wrap_up(GameObject item, int cost){

        // disable buy button for item
        item.gameObject.GetComponent<Button>().interactable = false;

        // take money
        this.ship_data.update_money(-cost);

        // set updated money value in UI
        // set player money UI text
        GameObject.Find("MoneyText").GetComponent<Text>().text = "$ " + this.ship_data.get_money(); 
    }

    public void on_back_button(){
        SceneManager.LoadScene("waypoint_panel");
    }
}
