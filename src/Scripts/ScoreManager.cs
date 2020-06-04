using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private float score=0;

    public static ScoreManager instance;

    public void InitiateScore() {
        score = 0;
    }

    public void IncreaseScore(float value) {
        score += value;
    }

    public void DecreaseScore(float value) {
        score -= value;
    }
	

}
