using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace overexcited.vr.managers {
    public class OXC_SceneManager : MonoBehaviour
    {
        public int currentSceneIndex { get; private set; }
        private int maxSceneIndex;
        // Start is called before the first frame update
        void Start()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            maxSceneIndex = SceneManager.sceneCountInBuildSettings;
        }


        public void LoadNextScene() {
            SceneManager.GetSceneByBuildIndex(++currentSceneIndex);
        }

        public void LoadScene(int sceneIndex){
            StartCoroutine(loadSceneDelayed(sceneIndex));
        }

        public void LoadScene(string sceneName){
            StartCoroutine(loadSceneDelayed(sceneName));
        }

        private IEnumerator loadSceneDelayed(int sceneIndex){
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }

        private IEnumerator loadSceneDelayed(string sceneName)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
