using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    interface IMainMenuView
    {

        event EventHandler<BlockViewClickChangedEventArgs> OnClickStartChanged;
        event EventHandler<BlockViewClickChangedEventArgs> OnClickAboutChanged;
    }

    namespace Impl
    {
        public class MainMenuView : MonoBehaviour, IMainMenuView
        {
            public event EventHandler<BlockViewClickChangedEventArgs> OnClickStartChanged;
            public event EventHandler<BlockViewClickChangedEventArgs> OnClickAboutChanged;
            
#pragma warning disable 649
            [SerializeField] private Button _Start;
            [SerializeField] private Button _About;
#pragma warning restore 649

            private void Start()
            {
                _Start.onClick.AddListener(OnClickStartEvent);
                _About.onClick.AddListener(OnClickAboutEvent);
            }

            public void OnClickStartEvent()
            {
                if (OnClickStartChanged != null)
                {
                    OnClickStartChanged(this, new BlockViewClickChangedEventArgs(true));
                }
            }

            public void OnClickAboutEvent()
            {
                if (OnClickAboutChanged != null)
                {
                    OnClickAboutChanged(this, new BlockViewClickChangedEventArgs(true));
                }
            }
        }
    }
}
