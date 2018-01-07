using Players;

namespace Weapons
{
    interface IWeapon
    {
        void Shoot(PlayerId playerId);
    }
}