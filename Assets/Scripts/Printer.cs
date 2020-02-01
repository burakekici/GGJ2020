using UnityEngine;


public class Printer: MonoBehaviour
{
    public static void PrintGreen(string text)
    {
        print("<color=green>" + text + "</color>");
    }
    
    
    public static void PrintRed(string text)
    {
        print("<color=red>" + text + "</color>");
    }
}

