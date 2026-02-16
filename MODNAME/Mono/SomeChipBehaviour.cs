using ChipLibrary;

namespace MODNAME.Mono
{
    public class SomeChipBehaviour : ChipBase
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