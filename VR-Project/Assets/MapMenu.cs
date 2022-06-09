using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapMenu : MonoBehaviour
{
    public static bool MenuIsOpen = false;
    public GameObject MapMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current.yButton.isPressed){
            if(MenuIsOpen){
                CloseMenu();
            }
            else{
                OpenMenu();
            }

        }
    }

    void CloseMenu(){
        MapMenuUI.SetActive(false);
        MenuIsOpen = false; 
    }

    void OpenMenu(){
        MapMenuUI.SetActive(true);
        MenuIsOpen = true;
    }
}
