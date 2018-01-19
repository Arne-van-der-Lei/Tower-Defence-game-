using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class StartModel
    {
        public int multiplyer = 0;

        public void Spawn()
        {
            multiplyer++;
            TozerDefenceAplicqtion.Instance.SpawnEnemies(multiplyer);
        }
    }
}
