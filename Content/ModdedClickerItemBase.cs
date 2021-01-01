﻿using ClickerClass;
using ClickerClass.Items;
using Terraria.ModLoader;

namespace ClickerClassExpansion.Content
{
    public abstract class ModdedClickerItemBase : ClickerItem
    {
        // If no image for our item is found, use Clicker Class' The Clicker item.
        public override string Texture
        {
            get
            {
                if (ModContent.GetTexture(base.Texture) != null)
                    return base.Texture;
                else
                {
                    mod.Logger.Warn($"Item image for {Name} not found! Falling back to ClickerClass' \"The Clicker\"...");
                    return "ClickerClass/Items/Weapons/Clickers/TheClicker";
                }
            }
        }

        public override bool Autoload(ref string name) => ClickerClassExpansion.ClickerClass.IsLoaded && ModDependencyIsLoaded;

        public virtual bool ModDependencyIsLoaded => true;

        public sealed override void SetStaticDefaults()
        {
            ClickerSystem.RegisterClickerWeapon(this);
            SafeSetStaticDefaults();
        }

        /// <summary>
        /// This is where you set all your item's static properties, such as names/translations and arrays in ItemID.Sets. This is called after SetDefaults on the initial ModItem.
        /// </summary>
        public virtual void SafeSetStaticDefaults()
        {
        }

        public sealed override void SetDefaults()
        {
            ClickerSystem.SetClickerWeaponDefaults(item);
            SafeSetDefaults();
        }

        /// <summary>
        /// This is where you set all your item's properties, such as width, damage, shootSpeed, defense, etc. For those that are familiar with tAPI, this has the same function as .json files.
        /// </summary>
        public virtual void SafeSetDefaults()
        {
        }
    }
}