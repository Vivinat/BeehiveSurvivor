﻿using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Bees;

public class WorkerBee : Bee
{
    private readonly HoneyService _honeyService;
    public WorkerBee(string name, int level,BeeEnum beeType, EatService eatService, HoneyService honeyService) : base(name, level, beeType, eatService)
    {
        _honeyService = honeyService;
    }

    public void CreateHoney()
    {
        _honeyService.CreateHoney(Level);
        EarnLevel();
    }
    
    
}