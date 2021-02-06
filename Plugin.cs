using MEC;
using RQReplace.Handlers;
using Synapse.Api.Plugin;

namespace RQReplace
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "Replaces Players that quit the Server during a round.",
        LoadPriority = 0,
        Name = "RQReplace",
        SynapseMajor = 2,
        SynapseMinor = 4,
        SynapsePatch = 2,
        Version = "b1.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "RQReplace")]
        public static Config Config;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("RQReplace loaded!");

            new EventHandlers();
        }

        public override void ReloadConfigs()
        {

        }
    }
}
