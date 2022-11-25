using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    // To hold the Player prefabs to switch through
    public GameObject[] Players;
    private GameObject Player;
    private GameObject CurrentPlayer;
    public GameObject Spawn;

    private int Index;

    // Buttons for switching character
    public Button OutfitButton;
    public Button ToneButton;

    public void Start() {
        Index = 0;
        Player = GameObject.Find("tan_hat_player");
        CurrentPlayer = Player;
    }

    public void Update() {

    }

    // To switch Outfit
    public void FireOutfit() {
        if (Index < 3) {
            Index += 3;
        } else {
            Index -= 3;
        }
        // Destroy old player obj
        GameObject.Destroy(CurrentPlayer);

        // Set new Player obj
        Player = Players[Index];

        // Instantiate new Player obj
        CurrentPlayer = GameObject.Instantiate(Player);
        CurrentPlayer.transform.position = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
    }

    // To switch Tone
    public void FireTone() {
        if (Index == 2 || Index == 5) {
            Index -= 2;
        } else {
            Index += 1;
        }
        // Destroy old player obj
        GameObject.Destroy(CurrentPlayer);

        // Set new Player obj
        Player = Players[Index];

        // Instantiate new Player obj
        CurrentPlayer = GameObject.Instantiate(Player);
        CurrentPlayer.transform.position = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
    }

    public GameObject ReturnCurrentPlayer() {
        return CurrentPlayer;
    }

}
