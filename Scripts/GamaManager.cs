using UnityEngine;
using UnityEngine.UI;

public class GamaManager : MonoBehaviour
{
    private static int killedZombies = 0;

    public static int KilledZombies
    {
        get { return killedZombies; }
    }

    public static void ResetGame()
    {
        killedZombies = 0;
    }
}