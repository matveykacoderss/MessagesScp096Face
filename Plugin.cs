using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp096;
using Exiled.Events.Handlers;
using System;
using System.ComponentModel;

namespace MessegeFaca096
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "AntiCheat and default.java";
        public override string Name => "SCP-096 Face Alert";
        public override Version Version => new Version(1, 0, 1);
        public override string Prefix => "096FaceAlert";

        public override void OnEnabled()
        {
            Scp096.AddingTarget += OnPlayerLook;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Scp096.AddingTarget -= OnPlayerLook;
            base.OnDisabled();
        }

        private void OnPlayerLook(AddingTargetEventArgs ev)
        {
            try
            {
                if (ev.Target != null && ev.Target.IsConnected)
                {
                    
                    ev.Target.ShowHint($"<color={Config.MessageColor}>Вы посмотрели на лицо SCP-096</color>", 5f);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка в обработчике события: {ex}");
            }
        }
    }

    public class Config : Exiled.API.Interfaces.IConfig
    {
        [Description("Включен ли плагин")]
        public bool IsEnabled { get; set; } = true;

        [Description("Цвет сообщения (HEX-код)")]
        public string MessageColor { get; set; } = "#FFC0CB"; 

        [Description("Режим отладки")]
        public bool Debug { get; set; } = false;
    }
}
