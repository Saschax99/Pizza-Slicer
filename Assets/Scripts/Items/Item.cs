using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
public class Item
{
    public enum ItemType
    {
        Saw1Skin, // SAW 1
        Saw2Skin, // SAW 2
        Saw3Skin, // SAW 3
        SmileySkin, // SMILEY 1
        Smiley2Skin, // SMILEY 2
        LightRedSkin, // RED
        LightGreenSkin, // GREEN
        LightOrangeSkin, // ORANGE
        BlackSkin, // BLACK

        Size,
        Velocity,
        DeathTimer,


        TwoXmultiplier,
        BiggerTargets,


        // Effects Good
        Usable_DecreaseTime,
        Usable_BiggerTargets,
        Usable_x2Coins,

        // Effects Bad
        Usable_IncreaseTime,
        Usable_SmallerTargets,
    }

    private bool[] Boughts;

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Saw1Skin:        return 0;
            case ItemType.Saw2Skin:        return 250;
            case ItemType.Saw3Skin:         return 250;
            case ItemType.SmileySkin:        return 250;
            case ItemType.Smiley2Skin:    return 250;
            case ItemType.LightRedSkin:        return 250;
            case ItemType.LightGreenSkin:       return 250;
            case ItemType.LightOrangeSkin:          return 250;
            case ItemType.BlackSkin:       return 250;

            case ItemType.Size:             return 150;
            case ItemType.Velocity:         return 150;
            case ItemType.DeathTimer:       return 150;

            case ItemType.TwoXmultiplier:   return 2500;
            case ItemType.BiggerTargets:    return 2250;
        }
    }

    public static int GetBoughtIndex(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Saw1Skin:        return 0;
            case ItemType.Saw2Skin:        return 1;
            case ItemType.Saw3Skin:         return 2;
            case ItemType.SmileySkin:        return 3;
            case ItemType.Smiley2Skin:    return 4;
            case ItemType.LightRedSkin:        return 5;
            case ItemType.LightGreenSkin:       return 6;
            case ItemType.LightOrangeSkin:          return 7;
            case ItemType.BlackSkin:       return 8;

            case ItemType.Size:             return 0;
            case ItemType.Velocity:         return 1;
            case ItemType.DeathTimer:       return 2;


            case ItemType.TwoXmultiplier:   return 0;
            case ItemType.BiggerTargets:    return 1;
        }
    }
    #region get loads
    public static ItemType GetLoad(int itemIndex, bool statsItem)
    {
        if (!statsItem)
        {
            switch (itemIndex)
            {
                default:
                case 0: return ItemType.Saw1Skin;
                case 1: return ItemType.Saw2Skin;
                case 2: return ItemType.Saw3Skin;
                case 3: return ItemType.SmileySkin;
                case 4: return ItemType.Smiley2Skin;
                case 5: return ItemType.LightRedSkin;
                case 6: return ItemType.LightGreenSkin;
                case 7: return ItemType.LightOrangeSkin;
                case 8: return ItemType.BlackSkin;
            }
        }
        else if (statsItem)
        {
            switch (itemIndex)
            {
                default:
                case 0: return ItemType.Size;
                case 1: return ItemType.Velocity;
                case 2: return ItemType.DeathTimer;
            }
        }
        else
        return 0;
    }
    public static ItemType GetLoad(int itemIndex, bool statsItem, bool usable)
    {
        if (statsItem)
            Debug.LogError("Cant access that");

        if (usable)
        {
            switch (itemIndex)
            {
                default:
                case 0: return ItemType.TwoXmultiplier;
                case 1: return ItemType.BiggerTargets;
            }
        }
        else
        return 0;
    }
    #endregion
    public static float GetScale(int stack)
    { 
        int[] stackScale = new int[3];

        if (SaveGame.Exists("Stacks"))
            stackScale = SaveGame.Load<int[]>("Stacks", 0);
        else
            stackScale[0] = 0;

        switch (stackScale[0])
        {
            default:
            case 0: return .8f;
            case 1: return .85f;
            case 2: return .9f;
            case 3: return 1f;
            case 4: return 1.05f;
            case 5: return 1.1f;
            case 6: return 1.2f;
            case 7: return 1.25f;
            case 8: return 1.3f;
        }
    }
    public static float GetVelocity(int stack)
    { 
        int[] stackVelo = new int[3];

        if (SaveGame.Exists("Stacks"))
            stackVelo = SaveGame.Load<int[]>("Stacks", 0);
        else
            stackVelo[1] = 0;

        switch (stackVelo[1])
        {
            default:
            case 0: return 0f;
            case 1: return 10;
            case 2: return 15f;
            case 3: return 22.5f;
            case 4: return 30f;
            case 5: return 50f;
            case 6: return 75f;
            case 7: return 100f;
            case 8: return 125f;
        }
    }
    public static float GetDeathTimer(int stack)
    { 
        int[] stackDeathTimer = new int[3];

        if (SaveGame.Exists("Stacks"))
            stackDeathTimer = SaveGame.Load<int[]>("Stacks", 0);
        else
            stackDeathTimer[2] = 0;

        switch (stackDeathTimer[2])
        {
            default:
            case 0: return 1;
            case 1: return 1.5f;
            case 2: return 2;
            case 3: return 2.5f;
            case 4: return 3;
            case 5: return 3.5f;
            case 6: return 4;
            case 7: return 4.5f;
            case 8: return 5;
        }
    }

    public static float GetBuyMultiplier(int index)
    {
        switch (index)
        {
            default:
            case 0: return 1;
            case 1: return 2f;
            case 2: return 4f;
            case 3: return 6f;
            case 4: return 8f;
            case 5: return 10f;
            case 6: return 12.5f;
            case 7: return 15f; // case 8 because 7 is the last state before buying 8 stat
        }
    }

    public static int GetMaxStack(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Size:         return 8;
            case ItemType.Velocity:     return 8;
            case ItemType.DeathTimer:   return 8;
        }
    }

    public static string GetName(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Saw1Skin:            return "saw blade 01";
            case ItemType.Saw2Skin:            return "saw blade 02";
            case ItemType.Saw3Skin:             return "saw blade 03";
            case ItemType.SmileySkin:            return "Smiley 01 Skin";
            case ItemType.Smiley2Skin:        return "Smiley 02 Skin";
            case ItemType.LightRedSkin:            return "Red Skin";
            case ItemType.LightGreenSkin:           return "Green Skin";
            case ItemType.LightOrangeSkin:              return "Orange Skin";
            case ItemType.BlackSkin:           return "Black Skin";

            case ItemType.Size:                 return "Size";
            case ItemType.Velocity:             return "Velocity";
            case ItemType.DeathTimer:           return "Death timer";

            case ItemType.Usable_BiggerTargets:     return "bigger Targets";
            case ItemType.Usable_DecreaseTime:      return "decreasing time";
            case ItemType.Usable_IncreaseTime:      return "increase time";
            case ItemType.Usable_SmallerTargets:    return "smaller Targets";
            case ItemType.Usable_x2Coins:           return "x2 multiplier";

            case ItemType.TwoXmultiplier:           return "2x multiplier";
            case ItemType.BiggerTargets:            return "bigger targets";
        }
    }

    public static ItemType GetUsableState(int index)
    {
        switch (index)
        {
            default:
            case 0: return ItemType.Usable_IncreaseTime;
            case 1: return ItemType.Usable_BiggerTargets;
            case 2: return ItemType.Usable_x2Coins;

            case 3: return ItemType.Usable_DecreaseTime;
            case 4: return ItemType.Usable_SmallerTargets;
        }
    }
}