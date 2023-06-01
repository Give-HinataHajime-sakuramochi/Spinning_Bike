using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIScale : MonoBehaviour
{
    float originWidth = 2560f;
    float originHeight = 1440f;


    void ScaleUIWithVideo()
    {
        RectTransform videoSize = GameObject.Find("VideoFrame").GetComponent<RectTransform>();

        float videoWidth = videoSize.rect.width;
        float videoHeight = videoSize.rect.height;

        // �p����
        float scalingRatioWidth = videoWidth / originWidth;
        float scalingRatioHeight = videoHeight / originHeight;
        float scalingRatio = Mathf.Min(scalingRatioWidth, scalingRatioHeight);

        // ���o UI 
        RectTransform speed = GameObject.Find("Speed").GetComponent<RectTransform>();
        RectTransform cadence = GameObject.Find("Cadence").GetComponent<RectTransform>();
        RectTransform angle = GameObject.Find("Angle").GetComponent<RectTransform>();
        RectTransform score = GameObject.Find("Score").GetComponent<RectTransform>();
        RectTransform score_minus = GameObject.Find("score_minus").GetComponent<RectTransform>();


        // ���s�p�� Scale�B��m
        Vector3 originalScale = speed.localScale;
        Vector3 newScale = originalScale * scalingRatio;
        
        Vector3 newPositionSpeed = speed.localPosition * scalingRatio;
        Vector3 newPositionCadence = cadence.localPosition * scalingRatio;
        Vector3 newPositionAngle = angle.localPosition * scalingRatio;
        Vector3 newPositionScore = score.localPosition * scalingRatio;

        Vector3 MinusScale = score_minus.localScale;
        Vector3 newMinusScale = MinusScale * scalingRatio;
        Vector3 newPositionScoreMinus = score_minus.localPosition * scalingRatio;

        // �վ� UI
        speed.localScale = newScale;
        speed.localPosition = newPositionSpeed;

        cadence.localScale = newScale;
        cadence.localPosition = newPositionCadence;
        
        angle.localScale = newScale;
        angle.localPosition = newPositionAngle;
        
        score.localScale = newScale;
        score.localPosition = newPositionScore;

        score_minus.localScale = newMinusScale;
        score_minus.localPosition = newPositionScoreMinus;

    }

    // loading ������ UI ���s�վ�
    private void OnDisable()
    {
        ScaleUIWithVideo();
    }

}
