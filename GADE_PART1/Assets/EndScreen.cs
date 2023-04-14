using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
        [SerializeField] private string nextSceneName;

        private void OnCollisionEnter(Collision collision)
        {
                if (collision.gameObject.CompareTag("Player"))
                {
                        SceneManager.LoadScene(nextSceneName);
                }
        }

}
