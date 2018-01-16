using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace View
{
    public class TowerViewValueUpgradeChangedEventArgs : EventArgs
    {
        public TowerViewValueUpgradeChangedEventArgs(bool upgrade)
        {
            Upgrade = upgrade;
        }

        public bool Upgrade { get; private set; }
    }

    public class TowerViewValueDeleteChangedEventArgs : EventArgs
    {
        public TowerViewValueDeleteChangedEventArgs(bool delete)
        {
            Delete = delete;
        }

        public bool Delete { get; private set; }
    }
    public interface ITowerView
    {
        event EventHandler<TowerViewValueDeleteChangedEventArgs> OnValueDeleteChanged;
        event EventHandler<TowerViewValueUpgradeChangedEventArgs> OnValueUpgradeChanged;

        string speedUpg { set; }
        string speedUpgLabel { set; }
        string rangeUpg { set; }
        string rangeUpgLabel { set; }
        string costUpg { set; }
        string costupgLabel { set; }
        string speed { set; }
        string speedLabel { set; }
        string range { set; }
        string rangeLabel { set; }
    }

    namespace impl
    {
        public class TowerView : MonoBehaviour, ITowerView
        {
            public string speedUpg { set { _SpeedUpg.text = value; } }
            public string speedUpgLabel { set { _SpeedUpgLabel.text = value; } }
            public string rangeUpg { set { _RangeUpg.text = value; } }
            public string rangeUpgLabel { set { _RangeUpgLabel.text = value; } }
            public string costUpg { set { _CostUpg.text = value; } }
            public string costupgLabel { set { _CostUpgLabel.text = value; } }
            public string speed { set { _Speed.text = value; } }
            public string speedLabel { set { _SpeedLabel.text = value; } }
            public string range { set { _Range.text = value; } }
            public string rangeLabel { set { _RangeLabel.text = value; } }

            public event EventHandler<TowerViewValueDeleteChangedEventArgs> OnValueDeleteChanged;
            public event EventHandler<TowerViewValueUpgradeChangedEventArgs> OnValueUpgradeChanged;

#pragma warning disable 649
            [SerializeField] private Text _SpeedUpg;
            [SerializeField] private Text _SpeedUpgLabel;
            [SerializeField] private Text _RangeUpg;
            [SerializeField] private Text _RangeUpgLabel;
            [SerializeField] private Text _CostUpg;
            [SerializeField] private Text _CostUpgLabel;
            [SerializeField] private Text _Speed;
            [SerializeField] private Text _SpeedLabel;
            [SerializeField] private Text _Range;
            [SerializeField] private Text _RangeLabel;
            [SerializeField] private Button _Upgrade;
            [SerializeField] private Button _Delete;
#pragma warning restore 649
            // Use this for initialization
            void Start()
            {
#if DEBUG
                Assert.IsNotNull(_SpeedUpg);
                Assert.IsNotNull(_SpeedUpgLabel);
                Assert.IsNotNull(_RangeUpg);
                Assert.IsNotNull(_RangeUpgLabel);
                Assert.IsNotNull(_CostUpg);
                Assert.IsNotNull(_CostUpgLabel);
                Assert.IsNotNull(_Speed);
                Assert.IsNotNull(_SpeedLabel);
                Assert.IsNotNull(_Range);
                Assert.IsNotNull(_RangeLabel);
#endif

                _Upgrade.onClick.AddListener(TowerViewValueUpgradeChanged);
                _Delete.onClick.AddListener(TowerViewValueDeleteChanged);
            }


            private void TowerViewValueDeleteChanged()
            {
                if (OnValueDeleteChanged != null)
                {
                    OnValueDeleteChanged(this, new TowerViewValueDeleteChangedEventArgs(true));
                }
            }

            private void TowerViewValueUpgradeChanged()
            {
                if (OnValueUpgradeChanged != null)
                {
                    OnValueUpgradeChanged(this, new TowerViewValueUpgradeChangedEventArgs(true));
                }
            }
        }
    }
}