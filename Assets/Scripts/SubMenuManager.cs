using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuManager : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();

    [SerializeField] MenuManager menuManager;

    [SerializeField] bool isMainMenu;

    private void OnEnable()
    {
        if (isMainMenu)
        {
            InitializeMe();
        }        
    }

    public void InitializeMe()
    {
        menuManager.InitializeMenu(buttons);
    }

}
