using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace View
{

    public interface IMoneyView
    {
        string Money { set; }
    }

    namespace impl
    {
        public class MoneyView : MonoBehaviour, IMoneyView
        {
            public string Money
            {
                set
                {
                    _Money.text = value;
                }
            }

#pragma warning disable 649
            [SerializeField] private Text _Money;
#pragma warning restore 649

            void Start()
            {
#if DEBUG
                Assert.IsNotNull(_Money);
#endif
            }
        }
    }
}
