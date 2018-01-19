using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    interface IAboutView
    {
        event EventHandler<BlockViewClickChangedEventArgs> OnClickAboutChanged;

    }

    namespace Impl
    {
        public class AboutView :  MonoBehaviour , IAboutView
        {
            public event EventHandler<BlockViewClickChangedEventArgs> OnClickAboutChanged;


#pragma warning disable 649
            [SerializeField] private Button _Back;
#pragma warning restore 649

            private void Start()
            {
                _Back.onClick.AddListener(OnClickBackEvent);
            }

            public void OnClickBackEvent()
            {
                if (OnClickAboutChanged != null)
                {
                    OnClickAboutChanged(this, new BlockViewClickChangedEventArgs(true));
                }
            }
        }
    }
}
