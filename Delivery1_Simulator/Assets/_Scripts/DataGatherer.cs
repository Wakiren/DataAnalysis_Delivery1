using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGatherer : MonoBehaviour
{
    struct Player 
    {
        public string name;
        public string country;
        public int age;
        public float gender;
        public DateTime dateTime;
    }
    
    struct Item
    {
        public int itemID;
        public DateTime dateTime;
        public uint sesionID;
    }

    struct SessionStart 
    {
        public DateTime dateTime;
        public uint playerID;
    }
    struct SessionEnd
    {
        public DateTime dateTime;
        public uint sessionID;
    }

    Player player;
    Item item;
    SessionStart sessionStart;
    SessionEnd sessionEnd;

    void OnEnable() 
    {
        Simulator.OnNewPlayer += OnPlayerConnected;
        Simulator.OnBuyItem += OnItemBought;
        Simulator.OnNewSession += OnNewSession;
    }

    void OnDisable()
    {
        Simulator.OnNewPlayer -= OnPlayerConnected;
        Simulator.OnBuyItem -= OnItemBought;
    }

    private void OnItemBought(int itemID, DateTime dateTime, uint sesionID)
    {
        item.itemID = itemID;
        item.dateTime = dateTime;
        item.sesionID = sesionID;
    }


    private void OnPlayerConnected(string name, string country, int age, float gender, DateTime dateTime)
    {
        player.name = name;
        player.country = country;
        player.age = age;
        player.gender = gender;
        player.dateTime = dateTime;
    }

    private void OnNewSession(DateTime dateTime, uint playerID)
    {
        sessionStart.dateTime = dateTime;
        sessionStart.playerID = playerID;
    }
}
