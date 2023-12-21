using UnityEngine;
using Yarn.Unity;

namespace CatUp
{
    public class ListViewAdvancedInput : MonoBehaviour
    {
        [SerializeField]
        private OptionsListView listView;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                listView.SelectOption(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                listView.SelectOption(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                listView.SelectOption(3);
            }

        }
    }

}