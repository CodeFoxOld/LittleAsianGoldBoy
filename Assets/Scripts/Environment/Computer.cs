﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chojo.LAG.Manager;

namespace Chojo.LAG.Environments {
    public class Computer {

        private GameManager gameManager = GameManager.GetInstance();

        private int level = 1;
        private int id;

        public Computer() {
            //id = gameManager.GetEnvironment().GetComputer().Count - 1;
        }
        public Computer(int startLevel) {
            level = startLevel;
        }
        
        public bool UpgradeComputer() {
            if (level < gameManager.GetConfigData().MaxComputerLevel
                && gameManager.GetCharacter().TakeMoney(gameManager.GetConfigData().getUpgradeCost(level, gameManager.GetConfigData().ComputerPrice))) {
                level = level + 1;
                Debug.Log("Computer " + id + " upgradet");
                return true;
            }
            return false;
        }

        public int GetLevel() {
            return level;
        }
        public int GetUpgradePrice() {
            return gameManager.GetConfigData().getUpgradeCost(level, gameManager.GetConfigData().ComputerPrice);
        }
    }

}