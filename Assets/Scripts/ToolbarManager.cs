using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarManager : MonoBehaviour
{
    private const int PICKUPCOIN_TOTAL = 7;
    private const int LASERSHOOT_TOTAL = 9;
    private const int EXPLOSION_TOTAL = 9;
    private const int POWERUPS_TOTAL = 9;
    private const int HITHURT_TOTAL = 10;
    private const int JUMP_TOTAL = 6;
    private const int BLIPSELECTION_TOTAL = 9;
    private const int DEATH_TOTAL = 8;
    private const int WIN_TOTAL = 7;
    private const int LOSE_TOTAL = 7;
    private const int _8BITMUSIC_TOTAL = 17;
    private const int _16BITMUSIC_TOTAL = 17;

    public GameObject fileDropdown;
    public GameObject editDropdown;
    public GameObject assetsDropdown;
    public GameObject windowDropdown;
    public GameObject helpDropdown;
    public GameObject aboutDropdown;

    public GameObject pickup_coinDropdown;
    public GameObject laser_shootDropdown;
    public GameObject explosionDropdown;
    public GameObject powerupsDropdown;
    public GameObject hit_hurtDropdown;
    public GameObject jumpDropdown;
    public GameObject blip_selectionDropdown;
    public GameObject deathDropdown;
    public GameObject winDropdown;
    public GameObject loseDropdown;
    public GameObject _8BitMusicDropdown;
    //public GameObject _16BitMusicDropdown;

    public GameObject editorThemesDropdown;

    private Camera cam;
    public Text code;
    public AudioClip[] clip;
    private AudioSource audioSource;

    void Awake()
    {
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }

    // TOOLBAR BUTTONS //
    public void File_Clicked()
    {
        Clear();
        Debug.Log("FileClicked");
        fileDropdown.SetActive(true);
    }

    public void Edit_Clicked()
    {
        Clear();
        editDropdown.SetActive(true);
    }

    public void Assets_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
    }

    public void Window_Clicked()
    {
        Clear();
        windowDropdown.SetActive(true);
    }

    public void Help_Clicked()
    {
        Clear();
        helpDropdown.SetActive(true);
    }

    public void About_Clicked()
    {
        Clear();
        aboutDropdown.SetActive(true);
    }
    // END OF TOOLBAR BUTTONS //

    // ASSET BUTTONS //
    public void PickupCoin_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        pickup_coinDropdown.SetActive(true);
    }
    public void LaserShoot_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        laser_shootDropdown.SetActive(true);
    }
    public void Explosion_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        explosionDropdown.SetActive(true);
    }
    public void Powerups_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        powerupsDropdown.SetActive(true);
    }
    public void HitHurt_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        hit_hurtDropdown.SetActive(true);
    }
    public void Jump_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        jumpDropdown.SetActive(true);
    }
    public void BlipSelection_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        blip_selectionDropdown.SetActive(true);
    }
    public void Death_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        deathDropdown.SetActive(true);
    }
    public void Win_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        winDropdown.SetActive(true);
    }
    public void Lose_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        loseDropdown.SetActive(true);
    }
    public void _8BitMusic_Clicked()
    {
        Clear();
        assetsDropdown.SetActive(true);
        _8BitMusicDropdown.SetActive(true);
    }
    // END OF ASSET BUTTONS //

    // ASSETS SOUND TRACKS BUTTONS //
    public void PickupCoinTrack_Clicked(int track)
    {
        int t = track;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void LaserShootTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void ExplosionTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void PowerupsTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void HitHurtTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL + POWERUPS_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void JumpTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL + POWERUPS_TOTAL + HITHURT_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void BlipSelectionTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL + POWERUPS_TOTAL + HITHURT_TOTAL + JUMP_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void DeathTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL + POWERUPS_TOTAL + HITHURT_TOTAL + JUMP_TOTAL + BLIPSELECTION_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void WinTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL + POWERUPS_TOTAL + HITHURT_TOTAL + JUMP_TOTAL + BLIPSELECTION_TOTAL + DEATH_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void LoseTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL + POWERUPS_TOTAL + HITHURT_TOTAL + JUMP_TOTAL + BLIPSELECTION_TOTAL + DEATH_TOTAL + WIN_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void _8BitSoundTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL + POWERUPS_TOTAL + HITHURT_TOTAL + JUMP_TOTAL + BLIPSELECTION_TOTAL + DEATH_TOTAL + WIN_TOTAL + LOSE_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    public void _16BitSoundTrack_Clicked(int track)
    {
        int t = track + PICKUPCOIN_TOTAL + LASERSHOOT_TOTAL + EXPLOSION_TOTAL + POWERUPS_TOTAL + HITHURT_TOTAL + JUMP_TOTAL + BLIPSELECTION_TOTAL + DEATH_TOTAL + WIN_TOTAL + LOSE_TOTAL + _8BITMUSIC_TOTAL;
        audioSource.clip = clip[t];
        audioSource.Play();
    }
    // END OF ASSETS SOUND TRACKS BUTTONS //

    public void EditorThemes_Clicked()
    {
        Clear();
        windowDropdown.SetActive(true);
        editorThemesDropdown.SetActive(true);
    }

    public void DefaultPreferences(string consoleHex, string codeHex, bool piro)
    {
        Clear();
        Color consoleColor;
        Color codeColor;
        ColorUtility.TryParseHtmlString(consoleHex, out consoleColor);
        ColorUtility.TryParseHtmlString(codeHex, out codeColor);
        cam.backgroundColor = consoleColor;
        code.color = codeColor;
    }

    public void Clear()
    {
        fileDropdown.SetActive(false);
        editDropdown.SetActive(false);
        assetsDropdown.SetActive(false);
        windowDropdown.SetActive(false);
        helpDropdown.SetActive(false);
        aboutDropdown.SetActive(false);
        pickup_coinDropdown.SetActive(false);
        laser_shootDropdown.SetActive(false);
        explosionDropdown.SetActive(false);
        powerupsDropdown.SetActive(false);
        hit_hurtDropdown.SetActive(false);
        jumpDropdown.SetActive(false);
        blip_selectionDropdown.SetActive(false);
        deathDropdown.SetActive(false);
        winDropdown.SetActive(false);
        loseDropdown.SetActive(false);
        _8BitMusicDropdown.SetActive(false);
        //_16BitMusicDropdown.SetActive(false);
        editorThemesDropdown.SetActive(false);

        if (audioSource.isPlaying)
            audioSource.Stop();
        
    }
}
