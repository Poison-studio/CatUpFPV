using UnityEngine;
using Yarn.Unity;

namespace CatUp
{
    public class ListViewAdvancedInput : MonoBehaviour
    {
        [SerializeField]
        private OptionsListView listView;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("1");
                listView.SelectOption(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("2");
                listView.SelectOption(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("3");
                listView.SelectOption(3);
            }

        }
    }

}