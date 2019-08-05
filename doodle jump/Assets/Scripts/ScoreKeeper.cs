using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score { get; private set; }

	void Start() {

        CameraTarget.OnChangeHeighStatic += OnChangeHeigh;

    }

    void OnChangeHeigh()
    {
        score += 10;
    }

    private void OnDisable()
    {
        CameraTarget.OnChangeHeighStatic -= OnChangeHeigh;
    }
}
