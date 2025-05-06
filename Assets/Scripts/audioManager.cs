using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class audioManager : MonoBehaviour {
    [SerializeField] private AudioSource pageTurn;
    [SerializeField] private AudioSource shortBeep;
    [SerializeField] private AudioSource clockTick;
    [SerializeField] private AudioSource coinShimmer;

    [SerializeField] private postStats postStats;

    void Start() {
        postStats.pesosGained.AddListener(playCoinShimmer);
    }

    public void playPageTurn() {
        if (pageTurn != null) {
            pageTurn.Play();
        }
    }

    public void playShortBeep() {
        if (shortBeep != null) {
            shortBeep.Play();
        }
    }

    public void playClockTick() {
        if (clockTick != null) {
            clockTick.Play();
        }
    }

    public void playCoinShimmer() {
        if (coinShimmer != null) {
            coinShimmer.Play();
        }
    }

}