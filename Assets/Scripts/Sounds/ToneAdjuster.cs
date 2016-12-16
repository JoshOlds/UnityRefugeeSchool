using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ToneAdjuster : MonoBehaviour
{

    public const float OneSemiTone = 1.05946f;
    public const float TwoSemiTone = 1.12245f;
    public const float ThreeSemiTone = 1.18919f;
    public const float FourSemiTone = 1.2599f;
    public const float FiveSemiTone = 1.33482f;
    public const float SixSemiTone = 1.41418f;
    public const float SevenSemiTone = 1.49827f;
    public const float EightSemiTone = 1.58736f;
    public const float NineSemiTone = 1.68174f;
    public const float TenSemiTone = 1.78174f;
    public const float ElevenSemiTone = 1.88768f;
    public const float TwelveSemiTone = 2.0f;

    private AudioSource sound;
    private float startingPitch;

    public float InspectorPitch;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        startingPitch = sound.pitch;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAdjustedAudio(float pitch, bool increaseTone)
    {
        sound.pitch = startingPitch;
        if (increaseTone) sound.pitch += (sound.pitch * pitch) - sound.pitch;
        else sound.pitch -= (sound.pitch * pitch) - sound.pitch;
        //Debug.Log(sound.pitch);
        sound.Play();
    }

    public void PlayPositiveAdjustedAudio()
    {
        PlayAdjustedAudio(InspectorPitch, true);
    }
    public void PlayNegativeAdjustedAudio()
    {
        PlayAdjustedAudio(InspectorPitch, false);
    }
    public void PlayUpOneTone()
    {
        PlayAdjustedAudio(OneSemiTone, true);
    }
    public void PlayDownOneTone()
    {
        PlayAdjustedAudio(OneSemiTone, false);
    }
    public void PlayUpTwoTones()
    {
        PlayAdjustedAudio(TwoSemiTone, true);
    }
    public void PlayDownTwoTones()
    {
        PlayAdjustedAudio(TwoSemiTone, false);
    }
    public void PlayUpThreeTones()
    {
        PlayAdjustedAudio(ThreeSemiTone, true);
    }
    public void PlayDownThreeTones()
    {
        PlayAdjustedAudio(ThreeSemiTone, false);
    }
    public void PlayUpFourTones()
    {
        PlayAdjustedAudio(FourSemiTone, true);
    }
    public void PlayDownFourTones()
    {
        PlayAdjustedAudio(FourSemiTone, false);
    }
    public void PlayUpFiveTones()
    {
        PlayAdjustedAudio(FiveSemiTone, true);
    }
    public void PlayDownFiveTones()
    {
        PlayAdjustedAudio(FiveSemiTone, false);
    }
    public void PlayUpSixTones()
    {
        PlayAdjustedAudio(SixSemiTone, true);
    }
    public void PlayDownSixTones()
    {
        PlayAdjustedAudio(SixSemiTone, false);
    }
    public void PlayUpSevenTones()
    {
        PlayAdjustedAudio(SevenSemiTone, true);
    }
    public void PlayDownSevenTones()
    {
        PlayAdjustedAudio(SevenSemiTone, false);
    }
    public void PlayUpEightTones()
    {
        PlayAdjustedAudio(EightSemiTone, true);
    }
    public void PlayDownEightTones()
    {
        PlayAdjustedAudio(EightSemiTone, false);
    }
    public void PlayUpNineTones()
    {
        PlayAdjustedAudio(NineSemiTone, true);
    }
    public void PlayDownNineTones()
    {
        PlayAdjustedAudio(NineSemiTone, false);
    }
    public void PlayUpTenTones()
    {
        PlayAdjustedAudio(TenSemiTone, true);
    }
    public void PlayDownTenTones()
    {
        PlayAdjustedAudio(TenSemiTone, false);
    }
    public void PlayUpElevenTones()
    {
        PlayAdjustedAudio(ElevenSemiTone, true);
    }
    public void PlayDownElevenTones()
    {
        PlayAdjustedAudio(ElevenSemiTone, false);
    }
    public void PlayUpTwelveTones()
    {
        PlayAdjustedAudio(TwelveSemiTone, true);
    }
    public void PlayDownTwelveTones()
    {
        PlayAdjustedAudio(TwelveSemiTone, false);
    }
}
