namespace DNADropperBot.Core
{
    public class Well
    {
        private bool _full;

        public Well() {
            _full = false;
        }

        public Well(bool full) {
            _full = full;
        }

        public bool Full {
            get {
                return _full;
            }
        }

        public void Fill() {
            _full = true;
        }
    }
}