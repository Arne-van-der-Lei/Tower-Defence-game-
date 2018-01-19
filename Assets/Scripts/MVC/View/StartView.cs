using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace View
{

    public class StartViewStartChangedEventArgs : EventArgs
    {

    }

    public interface IStartView
    {
        event EventHandler<StartViewStartChangedEventArgs> OnNextWaveChanged;
    }

    namespace impl
    {
        public class StartView : MonoBehaviour, IStartView
        {
            public event EventHandler<StartViewStartChangedEventArgs> OnNextWaveChanged;


    #pragma warning disable 649
            [SerializeField] private Button _button;
    #pragma warning restore 649

            private void Start()
            {
                _button.onClick.AddListener(OnClickEvent);
            }

            public void OnClickEvent()
            {
                if(OnNextWaveChanged != null)
                {
                    OnNextWaveChanged(this, new StartViewStartChangedEventArgs());
                }
            }
        }
    }
}
