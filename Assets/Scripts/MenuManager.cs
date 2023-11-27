using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] List<Button> buttonList = new List<Button>();

    [SerializeField] int activeButtIndex;
    [SerializeField] Button activeButton;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (activeButton != null)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                if (activeButtIndex < buttonList.Count - 1)
                {
                    activeButtIndex++;
                    activeButton = buttonList[activeButtIndex];
                    EventSystem.current.SetSelectedGameObject(activeButton.gameObject, new BaseEventData(EventSystem.current));
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (activeButtIndex > 0)
                {
                    activeButtIndex--;
                    activeButton = buttonList[activeButtIndex];
                    EventSystem.current.SetSelectedGameObject(activeButton.gameObject, new BaseEventData(EventSystem.current));
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                activeButton.onClick.Invoke();
            }
            
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (buttonList.Count > 0)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    activeButton = buttonList[0];
                    activeButtIndex = 0;
                    EventSystem.current.SetSelectedGameObject(activeButton.gameObject, new BaseEventData(EventSystem.current));
                }
            }                
        }

        if (Input.GetAxis("Mouse X") > 0)
        {            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            activeButton = null;
            EventSystem.current.SetSelectedGameObject(null);
        }
        
    }

    public void InitializeMenu(List<Button> buttons)
    {
        buttonList.Clear();
        buttonList.AddRange(buttons);

        if (buttonList.Count > 0)
        {
            activeButton = buttonList[0];
            activeButtIndex = 0;
            EventSystem.current.SetSelectedGameObject(activeButton.gameObject, new BaseEventData(EventSystem.current));
        }
    }
}
