using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    public int sceneBuildIndex;

    [SerializeField] private RawImage img;
    [SerializeField] private AnimationCurve fadeCurve;
    [SerializeField] private Spawn connection;
    [SerializeField] private Transform spawnPoint;

    private void Start() {
        StartCoroutine(FadeIn());

        if (connection == Spawn.ActiveConnection) {
            FindAnyObjectByType<Ninja>().transform.position = spawnPoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Spawn.ActiveConnection = connection;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    IEnumerator FadeIn() {
        float t = 1f;

        while (t > 0f) {
            float a = fadeCurve.Evaluate(t);

            t = t - Time.deltaTime;
            Color color = img.color;
            color.a = a;
            img.color = color;

            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene) {
        float t = 0f;

        while (t < 1f) {
            float a = fadeCurve.Evaluate(t);

            t = t + Time.deltaTime;

            Color color = img.color;
            color.a = a;
            img.color = color;

            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    }
}