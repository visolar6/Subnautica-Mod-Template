using ChipLibrary;

namespace MODNAME.Mono
{
    /// <summary>
    /// Example chip behaviour. This class will be instantiated for each equipped chip of the corresponding type, and will persist until the chip is unequipped.
    /// </summary>
    public class ReactiveShieldingChipBehaviour : ChipBase
    {
        public override bool UsesUpdate => true;

        public override void OnEquip()
        {
            base.OnEquip();

            // Enable chip logic
        }

        public override void OnUnequip()
        {
            base.OnUnequip();

            // Disable chip logic
        }

        public override void EquippedUpdate()
        {
            // Logic to run every frame while chip is equipped
        }
    }
}
