using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticHolder : MonoBehaviour
{

    public static int Drinks = 0;
    public static int Drinks_sinceLevelStart = 0;
    public static int DrunknessLevel = 0;
    public static int DrunknessLevel_threshold = 0;
    public static int Combo = 0;
    public static int Combo_Multiplier = 1;
    public static int Disoriented_level = 0;
    public static float CollectedTime = 0f;
    public static int CollectedTime_accumulated = 0;

    public static int Score;

    public static bool Menu_active = true;
    public static bool Countdown_done = false;
    public static bool TimeOver = false;
    public static bool GameWon = false;
    public static bool Disoriented = false;
    public static bool IsHoldingGlas = false;
    
}
