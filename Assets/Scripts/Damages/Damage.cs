using System;
using Players;

namespace Damages
{
    [Serializable]
    public struct Damage
    {
        public int Value;
        public PlayerId Shooter;
    }
}