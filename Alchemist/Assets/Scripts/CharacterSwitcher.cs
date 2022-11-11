using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    // To hold the sprites to switch through
    public Sprite[] Sprites;

    // To hold the current Sprite
    private Sprite Current;
    private int Index;

    public Image Bilby;

    // Buttons for switching character
    public Button OutfitButton;
    public Button ToneButton;

    public void Start() {
        Index = 0;
        Current = Sprites[Index];
    }

    // To switch Outfit
    public void FireOutfit() {
        if (Index < 3) {
            Index += 3;
        } else {
            Index -= 3;
        }
        // print(Index);
        Current = Sprites[Index];
        Bilby.sprite = Current;
    }

    // To switch Tone
    public void FireTone() {
        if (Index == 2 || Index == 5) {
            Index -= 2;
        } else {
            Index += 1;
        }
        // print(Index);
        Current = Sprites[Index];
        Bilby.sprite = Current;
    }

}
