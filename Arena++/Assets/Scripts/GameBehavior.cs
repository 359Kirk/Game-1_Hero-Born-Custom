using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showLossScreen = false;
    private int _itemsCollected = 0;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject Minimap;

    public int Items
    {
        get { return _itemsCollected; }
        set { _itemsCollected = value;
            if(_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 3;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's gotta hurt.";
            }
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }
    public void BoostHealth(int boost)
    {
        _playerHP += boost;
        if (_playerHP > 3)
        {
            _playerHP = 3;
        }
    }

    private int _playerAmmo = 10;
    public int ammo
    {
        get { return _playerAmmo; }
        set
        {
            _playerAmmo = value;
            if (_playerAmmo <= 0)
            {
                labelText = "Out of Ammo! BREAK CONTACT!";
            }
        }
    }
    public void AmmoResupply(int boost)
    {
        _playerAmmo += boost;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20,20,150,25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20,45,150,25), "Ammo: " + _playerAmmo);
        GUI.Box(new Rect(20,70,150,25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50,300,20), labelText);
        if(showWinScreen)
        {
            WinScreen.SetActive(true);
            Minimap.SetActive(false);
        }
        if (showLossScreen)
        {
            LoseScreen.SetActive(true);
            Minimap.SetActive(false);
        }
    }
}

