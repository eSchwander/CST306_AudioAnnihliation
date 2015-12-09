﻿using UnityEngine;
using System.Collections;

public class MoneyManager {
	//Singleton class used to keep track of your money

	private static MoneyManager instance;

	private int money;

	private MoneyManager() {
		money = 0;
	}
	
	public static MoneyManager getInstance(){
		if (instance == null)
		{
			instance = new MoneyManager();
		}
		return instance;

	}

	public void gainMoney(int amount){
		money += amount;
	}

	public void spendMoney(int amount){
		money -= amount;
	}
}