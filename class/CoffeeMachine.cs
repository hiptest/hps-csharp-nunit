namespace Hiptest.Publisher.Samples {
    using System.Collections.Generic;

    class CoffeeMachine {
        public bool CoffeeServed = false;
        public string Message = "";

        private int _tank;
        private int _beans;
        private int _grounds;
        private bool _started;
        private string _lang;
        private bool _settingsDisplayed = false;
        private string _waterHardness = "2";
        private string _grinder = "medium";

        private static readonly Dictionary<string, string> _english = new Dictionary<string, string>
            {
                {"tank", "Fill tank"},
                {"beans", "Fill beans"},
                {"grounds", "Empty grounds"},
                {"ready", "Ready"},
                {"settings", "Settings:\n - 1: water hardness\n - 2: grinder"}
            };

        private static readonly Dictionary<string, string> _french = new Dictionary<string, string>
            {
                {"tank", "Remplir reservoir"},
                {"beans", "Ajouter grains"},
                {"grounds", "Vider marc"},
                {"ready", "Pret"},
                {"settings", "Configurer:\n - 1: durete de l'eau\n - 2: mouture"}
            };

        public CoffeeMachine() {
            _started = false;
            FillTank();
            FillBeans();
            EmptyGrounds();
        }

        public void ShowSettings() {
            _settingsDisplayed = true;
            UpdateMessage();
        }

        public void QuitSettings() {
            _settingsDisplayed = false;
            UpdateMessage();
        }

        public Dictionary<string, string> GetSettings() {
            return new Dictionary<string, string> {
                {"water hardness", _waterHardness},
                {"grinder", _grinder}
            };
        }

        public void Start (string lang = "en") {
            _lang = lang;
            _started = true;
            CoffeeServed = true;
            UpdateMessage();
        }

        public void Stop () {
            _started = false;
            UpdateMessage();
        }

        public void TakeCoffee () {
            if (!_started) {
              return;
            }

            if (_tank == 0 || _beans == 0) {
              CoffeeServed =  false;
              return;
            }

            CoffeeServed = true;
            _tank -= 1;
            _beans -=1;
            _grounds += 1;
            UpdateMessage();
        }

        public void FillTank () {
            _tank = 60;
            UpdateMessage();
        }

        public void FillBeans () {
            _beans = 40;
            UpdateMessage();
        }

        public void EmptyGrounds () {
            _grounds = 0;
            UpdateMessage();
        }

        private void UpdateMessage() {
            if (!_started) {
                Message =  "";
                return;
            }

            if (_settingsDisplayed) {
                Message = GetMessage("settings");
                return;
            }

            if (_tank <= 10) {
                Message = GetMessage("tank");
                return;
            }

            if (_beans < 3) {
                Message = GetMessage("beans");
                return;
            }

            if (_grounds >= 30) {
                Message = GetMessage("grounds");
                return;
            }
            Message = GetMessage("ready");
        }

        private string GetMessage(string key) {
            var lang = _english;
            if (_lang == "fr") {lang = _french;}

            return lang[key];
        }
    }
}