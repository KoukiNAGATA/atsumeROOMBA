using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SyototsuScript : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText;
        public ParticleSystem particle5;
        public ParticleSystem particle10;
        public ParticleSystem particle20;
        public AudioClip audio;

        private int score;
        private AudioSource audioSource;

        // Use this for initialization
        void Start()
        {
            score = 0;
            ScoreText.text = score.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision Gomi)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audio;
            if (Gomi.gameObject.tag == "bottle")
            {
                Destroy(Gomi.gameObject);
                particle5.Play();
                audioSource.Play();
                score += 5;
                SetCountText();
            }
            else if (Gomi.gameObject.tag == "box")
            {
                Destroy(Gomi.gameObject);
                score += 20;
                particle20.Play();
                audioSource.Play();
                SetCountText();
            }
            else if (Gomi.gameObject.tag == "desk")
            {
                Destroy(Gomi.gameObject);
                score += 10;
                particle10.Play();
                audioSource.Play();
                SetCountText();
            }
        }

        void SetCountText()
        {
            // スコアの表示を更新
            ScoreText.text = score.ToString();
        }
}
