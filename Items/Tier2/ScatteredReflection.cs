﻿using R2API;
using RoR2;
using RoR2.Orbs;
using UnityEngine;
using Hex3Mod.HelperClasses;
using Hex3Mod.Utils;
using static Hex3Mod.Main;

namespace Hex3Mod.Items
{
    /*
    Scattered Reflection provides a unique item synergy for the simple Shard Of Glass
    It also provides damage reduction and retaliation in one, making it ideal for players who want to tank some damage
    */
    public static class ScatteredReflection
    {
        static string itemName = "ScatteredReflection";
        static string upperName = itemName.ToUpper();
        public static ItemDef itemDef;
        public static GameObject LoadPrefab()
        {
            GameObject pickupModelPrefab = MainAssets.LoadAsset<GameObject>("Assets/Models/Prefabs/ScatteredReflectionPrefab.prefab");
            if (debugMode)
            {
                pickupModelPrefab.GetComponentInChildren<Renderer>().gameObject.AddComponent<MaterialControllerComponents.HGControllerFinder>();
            }
            return pickupModelPrefab;
        }
        public static Sprite LoadSprite()
        {
            return MainAssets.LoadAsset<Sprite>("Assets/Icons/ScatteredReflection.png");
        }
        public static ItemDef CreateItem()
        {
            ItemDef item = ScriptableObject.CreateInstance<ItemDef>();

            item.name = itemName;
            item.nameToken = "H3_" + upperName + "_NAME";
            item.pickupToken = "H3_" + upperName + "_PICKUP";
            item.descriptionToken = "H3_" + upperName + "_DESC";
            item.loreToken = "H3_" + upperName + "_LORE";

            item.tags = new ItemTag[]{ ItemTag.Damage, ItemTag.Utility, ItemTag.AIBlacklist, ItemTag.BrotherBlacklist };
            item._itemTierDef = helpers.GenerateItemDef(ItemTier.Tier2);
            item.canRemove = true;
            item.hidden = false;
            item.requiredExpansion = Hex3ModExpansion;

            item.pickupModelPrefab = LoadPrefab();
            item.pickupIconSprite = LoadSprite();

            return item;
        }

        public static ItemDisplayRuleDict CreateDisplayRules()
        {
            GameObject ItemDisplayPrefab = helpers.PrepareItemDisplayModel(PrefabAPI.InstantiateClone(LoadPrefab(), LoadPrefab().name + "Display", false));
            /*
            GameObject ItemDisplayPrefab = PrefabAPI.InstantiateClone(new GameObject("H3_ScatteredReflectionFollower"), "H3_ScatteredReflectionFollower", false);
            ItemFollower itemFollower = ItemDisplayPrefab.AddComponent<ItemFollower>();
            itemFollower.targetObject = ItemDisplayPrefab;
            itemFollower.followerPrefab = LoadPrefab();
            itemFollower.distanceDampTime = 0.1f;
            itemFollower.distanceMaxSpeed = 200f;

            Just implement follower behavior in a later update
            */

            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();
            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.4304F, -0.81567F, 0.12051F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.4304F, -0.81567F, 0.12051F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Hip",
                        localPos = new Vector3(-3.67421F, -1.17204F, -5.27553F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.46104F, 0.46104F, 0.46104F)
                    }
                }
            );
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.58279F, -0.3402F, 0.63118F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.4304F, -0.81567F, 0.12051F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.4304F, -0.81567F, 0.12051F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "PlatformBase",
                        localPos = new Vector3(-0.67259F, 0.96418F, -1.43672F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.1357F, 0.1357F, 0.1357F)
                    }
                }
            );
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.58465F, -0.69641F, 0.35263F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Hip",
                        localPos = new Vector3(-4.59637F, -1.1522F, 3.66788F),
                        localAngles = new Vector3(319.2833F, 0F, 0F),
                        localScale = new Vector3(0.49983F, 0.49983F, 0.49983F)
                    }
                }
            );
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.54088F, -0.86142F, 0.10506F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.4304F, -0.81567F, 0.12051F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("EngiTurretBody", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Base",
                        localPos = new Vector3(-1.95867F, 1.47275F, 0.22363F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.31116F, 0.31116F, 0.31116F)
                    }
                }
            );
            rules.Add("EngiWalkerTurretBody", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Base",
                        localPos = new Vector3(-2.20764F, 1.68749F, 0.22363F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.31494F, 0.31494F, 0.31494F)
                    }
                }
            );
            rules.Add("mdlScav", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-15.17687F, -0.5384F, 1.92231F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(1.66772F, 1.66772F, 1.66772F)
                    }
                }
            );
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.65262F, -0.5386F, 0.1665F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(-0.5793F, -0.49399F, -0.44001F),
                        localAngles = new Vector3(0.00001F, 41.26042F, 0F),
                        localScale = new Vector3(0.07054F, 0.07054F, 0.07054F)
                    }
                }
            );

            return rules;
        }

        public static void AddTokens()
        {
            LanguageAPI.Add("H3_" + upperName + "_NAME", "Scattered Reflection");
            LanguageAPI.Add("H3_" + upperName + "_PICKUP", "Block and reflect some of the damage you take back to attackers. Reflect more with each <style=cWorldEvent>Shard Of Glass</style> you own.");
            LanguageAPI.Add("H3_" + upperName + "_LORE", "An aggregate of shattered souls\n\nLost to the wind and to time\n\nThey form a ward to protect you\n\nThe only one they can follow home");
        }
        public static void UpdateItemStatus(Run run)
        {
            if (!ScatteredReflection_Enable.Value)
            {
                LanguageAPI.AddOverlay("H3_" + upperName + "_NAME", "Scattered Reflection" + " <style=cDeath>[DISABLED]</style>");
                if (run && run.availableItems.Contains(itemDef.itemIndex)) { run.availableItems.Remove(itemDef.itemIndex); }
            }
            else
            {
                LanguageAPI.AddOverlay("H3_" + upperName + "_NAME", "Scattered Reflection");
                if (run && !run.availableItems.Contains(itemDef.itemIndex) && run.IsExpansionEnabled(Hex3ModExpansion)) { run.availableItems.Add(itemDef.itemIndex); }
            }
            LanguageAPI.AddOverlay("H3_" + upperName + "_DESC", string.Format("<style=cIsUtility>Block and reflect {0}% of all received damage</style> back to your attacker, magnifying it by <style=cIsDamage>{1}%</style> <style=cStack>(+{1}% per stack)</style>. For every <style=cIsUtility>Shard Of Glass</style> in your inventory, <style=cIsUtility>reflect {2}%</style> <style=cStack>(+{2}% per stack)</style> <style=cIsUtility>more damage</style>.", ScatteredReflection_DamageReflectPercent.Value * 100f, ScatteredReflection_DamageReflectBonus.Value * 100f, ScatteredReflection_DamageReflectShardStack.Value * 100f));
        }

        private static void AddHooks()
        {
            void TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
            {
                if (self.body && self.body.master && self.body.teamComponent && self.body.inventory && self.body.inventory.GetItemCount(itemDef) > 0)
                {
                    CharacterBody body = self.body;
                    Inventory inventory = body.inventory;
                    int itemCount = inventory.GetItemCount(itemDef);
                    int shardCount = 0;
                    if (ItemCatalog.GetItemDef(ItemCatalog.FindItemIndex("ShardOfGlass")) != null) // If shard is not present, nothing will be affected
                    {
                        shardCount = inventory.GetItemCount(ItemCatalog.GetItemDef(ItemCatalog.FindItemIndex("ShardOfGlass")));
                    }

                    if (damageInfo.attacker && damageInfo.attacker.TryGetComponent(out CharacterBody enemyBody) && enemyBody.teamComponent && body != enemyBody && body.teamComponent.teamIndex != enemyBody.teamComponent.teamIndex && damageInfo.damage > 0.1f && !damageInfo.procChainMask.HasProc(ProcType.Thorns))
                    {
                        shardCount *= inventory.GetItemCount(itemDef); // Stacks of Scattered Reflection now strengthen the synergy
                        float totalReflectPercent = ScatteredReflection_DamageReflectPercent.Value + (shardCount * ScatteredReflection_DamageReflectShardStack.Value);
                        if (totalReflectPercent > 0.8f)
                        { 
                            totalReflectPercent = 0.8f; // Prevent damage capped at 80%
                        }
                        float damageReflected = damageInfo.damage * totalReflectPercent;
                        damageInfo.damage -= damageReflected;

                        ProcChainMask mask = new ProcChainMask();
                        mask.AddProc(ProcType.Thorns);

                        LightningOrb lightningOrb = new LightningOrb();
                        lightningOrb.attacker = body.gameObject;
                        lightningOrb.bouncedObjects = null;
                        lightningOrb.bouncesRemaining = 0;
                        lightningOrb.damageCoefficientPerBounce = 1f;
                        lightningOrb.damageColorIndex = DamageColorIndex.Item;
                        lightningOrb.damageValue = damageReflected + ((damageReflected * ScatteredReflection_DamageReflectBonus.Value) * itemCount);
                        lightningOrb.damageType = DamageType.Generic;
                        lightningOrb.isCrit = false;
                        lightningOrb.lightningType = LightningOrb.LightningType.RazorWire;
                        lightningOrb.origin = body.corePosition;
                        lightningOrb.procChainMask = mask;
                        lightningOrb.procCoefficient = 0f;
                        lightningOrb.range = 0f;
                        lightningOrb.teamIndex = body.teamComponent.teamIndex;
                        lightningOrb.target = enemyBody.mainHurtBox;
                        OrbManager.instance.AddOrb(lightningOrb);
                        Util.PlaySound(EntityStates.BrotherMonster.Weapon.FireLunarShards.fireSound, body.gameObject);
                    }
                }
                orig(self, damageInfo);
            }
            On.RoR2.HealthComponent.TakeDamage += TakeDamage;
        }

        public static void Initiate()
        {
            itemDef = CreateItem();
            ItemAPI.Add(new CustomItem(itemDef, CreateDisplayRules()));
            AddTokens();
            UpdateItemStatus(null);
            AddHooks();
        }
    }
}
