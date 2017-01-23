
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts
{
    using UnityEngine.SceneManagement;

    public class UiController : MonoBehaviour
    {
        // menu/options objects
        static GameObject[] menuObjects;
        static GameObject[] optionsObjects;
        public static bool optionsMenu;
        public static bool mainMenu;

        private bool onMainMenu = true;

        // audio
        static bool muteAudio;
        public Slider SfxVolumeSlider;
        //public float volumeS;
        //public AudioSource volumeAudio;


        void Start()
        {
            //PlayerPrefs.DeleteAll();
            menuObjects = GameObject.FindGameObjectsWithTag("MainMenu");
            optionsObjects = GameObject.FindGameObjectsWithTag("Options");

            ToggleOptions();
        }


        void Update()
        {
            // press esc to open and close the options menu
            if (!this.onMainMenu && Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleOptions();
            }
        }

        // removes the menu when the game begins
        public void LoadGame()
        {
            ToggleMenu();
            this.onMainMenu = false;
        }

        // deactivates the main menu objects, activates the options objects
        public void Options()
        {
            ToggleOptions();
            ToggleMenu();
        }

        // opposite of above
        public void Back()
        {
            ToggleOptions();
            if (this.onMainMenu)
            {
                ToggleMenu();
            }
        }

        // mutes sound
        public void MuteSound()
        {
            muteAudio = !muteAudio;

            if (!muteAudio)
            {
                this.AdjustSfxVolume();
            }
            else
            {
                AudioListener.volume = 0f;
            }
        }

        public void AdjustSfxVolume()
        {
            if (!muteAudio) {
                AudioListener.volume = this.SfxVolumeSlider.value;
            }
        }

        // exits the game
        public void ExitApplication()
        {
            Application.Quit();
        }

        // activates/deactivates the options objects
        private static void ToggleOptions()
        {
            foreach (var o in optionsObjects)
            {
                o.SetActive(optionsMenu);
            }
            optionsMenu = !optionsMenu;
        }

        // activates/deactivates the main menu objects
        private static void ToggleMenu()
        {
            Debug.Log("Menu");
            foreach (var m in menuObjects)
            {
                m.SetActive(mainMenu);
            }
            mainMenu = !mainMenu;
        }
    }
}
