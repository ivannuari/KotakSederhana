using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ivannuari
{
    public class Page : MonoBehaviour
    {
        public PageName nama;

        protected virtual void OnEnable()
        {
            Button[] allButtons = GetComponentsInChildren<Button>();

            if(allButtons.Length > 0)
            {
                foreach (var item in allButtons)
                {
                    item.onClick.AddListener(() => AudioManager.Instance?.MainkanSuara("klik"));
                }
            }
        }

        protected void ChangeScene(string namaScene)
        {
            SceneManager.LoadScene(namaScene);
        }

        public virtual void SetNomor(int nomor)
        {

        }
    }
}


public enum PageName
{
    Menu,
    Help,
    Level,
    Load
}

