using MEC;
using RQReplace.Handlers;
using Synapse.Api.Plugin;
using Synapse.Translation;

namespace RQReplace
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "Replaces Players that quit the Server during a round.",
        LoadPriority = 0,
        Name = "RQReplace",
        SynapseMajor = 2,
        SynapseMinor = 7,
        SynapsePatch = 0,
        Version = "2.1.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "RQReplace")]
        public static Config Config;

        [SynapseTranslation]
        public static SynapseTranslation<PluginTranslation> PluginTranslation;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("RQReplace loaded!");
            PluginTranslation.AddTranslation(new PluginTranslation());

            PluginTranslation.AddTranslation(new PluginTranslation
            {
                ReplaceBroadcast = "<b><i>Du hast einen Spieler ersetzt!</i></b>",
            }, "GERMAN");

            PluginTranslation.AddTranslation(new PluginTranslation
            {
                ReplaceBroadcast = "<b><i>Vous avez remplacé un Joueur!</i></b>",
            }, "FRENCH");

            PluginTranslation.AddTranslation(new PluginTranslation
            {
                ReplaceBroadcast = "<b><i>Właśnie zastąpiłeś jednego z graczy!</i></b>",
            }, "POLISH");

            //Feel free to ask me or create a PR in order to add more languages
            new EventHandlers();
        }

    }
}
