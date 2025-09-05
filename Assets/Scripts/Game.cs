using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game
    {
        public GameState state;
        
        public List<Boss> redBossList;
        public List<Boss> blueBossList;
        public List<Soldier> redSoldierList;
        public List<Soldier> blueSoldierList;
        public readonly GameObject ground;

        public Game(GameObject ground)
        {
            this.ground=ground;
            this.redBossList = new List<Boss>();
            this.blueBossList = new List<Boss>();
            this.redSoldierList = new List<Soldier>();
            this.blueSoldierList = new List<Soldier>();
        }

        public void Start()
        {
            state = GameState.PLAYING;
            redBossList.Add(new Boss(Camp.RED,this));
            for (int i = 0; i < 5000; i++)
            {
                blueSoldierList.Add(new Soldier(Camp.BLUE,this));    
            }
            blueBossList.Add(new Boss(Camp.BLUE,this));
            for (int i = 0; i < 5000; i++)
            {
                redSoldierList.Add(new Soldier(Camp.RED,this));    
            }
        }

        public void Update()
        {
            if (state == GameState.PLAYING)
            {
                Debug.Log("游戏运行中");
                UpdatePlaying();
            }
        }
        
        public void UpdatePlaying()
        {
            foreach (var boss in redBossList)
            {
                boss.Update();
            }
            foreach (var boss in blueBossList)
            {
                boss.Update();
            }
            foreach (var soldier in redSoldierList)
            {
                soldier.Update();
            }
            foreach (var soldier in blueSoldierList)
            {
                soldier.Update();
            }
        }
        
    }
}