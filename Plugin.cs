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
        SynapseMajor = 4,
        SynapseMinor = 5,
        SynapsePatch = 2,
        Version = "1.2.1"
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
