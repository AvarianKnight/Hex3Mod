﻿using R2API;
using RoR2;
using UnityEngine;
using static Hex3Mod.Main;

namespace Hex3Mod.Artifacts
{
    public class ArtifactOfCorruption
    {
        static string artifactName = "ArtifactOfCorruption";
        static string upperName = artifactName.ToUpper();
        static ArtifactDef artifactDefinition = CreateArtifact(); // Basically the same as making an item
        public static bool artifactEnabled => RunArtifactManager.instance.IsArtifactEnabled(artifactDefinition);


        public static ArtifactDef CreateArtifact()
        {
            ArtifactDef artifact = ScriptableObject.CreateInstance<ArtifactDef>();

            artifact.cachedName = artifactName;
            artifact.nameToken = "H3_" + upperName + "_NAME";
            artifact.descriptionToken = "H3_" + upperName + "_DESC";
            artifact.requiredExpansion = Hex3ModExpansion;

            artifact.smallIconSelectedSprite = MainAssets.LoadAsset<Sprite>("Assets/Icons/ArtifactOfCorruption_On.png");
            artifact.smallIconDeselectedSprite = MainAssets.LoadAsset<Sprite>("Assets/Icons/ArtifactOfCorruption_Off.png");

            return artifact;
        }
        public static void AddTokens()
        {
            LanguageAPI.Add("H3_" + upperName + "_NAME", "Artifact of Bugs");
            LanguageAPI.Add("H3_" + upperName + "_DESC", "Gives you one <style=cIsVoid>Corrupting Parasite</style> each stage.");
        }

        public static void AddHooks() // Insert hooks here
        {
            void giveParasite(CharacterMaster master)
            {
                if (artifactEnabled && master.inventory)
                {
                    master.inventory.GiveItemString("CorruptingParasite");
                }
            }

            On.RoR2.CharacterMaster.OnServerStageBegin += (orig, self, stage) =>
            {
                orig(self, stage);
                giveParasite(self);
            };
        }
        public static void Initiate()
        {
            CreateArtifact();
            ContentAddition.AddArtifactDef(artifactDefinition);
            AddTokens();
            AddHooks();
        }
    }
}
