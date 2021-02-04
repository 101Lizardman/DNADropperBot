namespace DNADropperBot.Core
{
    public class State
    { 
        private int? _x = null;
        private int? _y = null;

        private Well[,] _wells;

        public State() {
            _x = null;
            _y = null;
            _wells = InstanciateWells();
        }

        public State(int? x, int? y, Well[,] wells) {
            _x = x;
            _y = y;
            _wells = wells;
        }

        public int? X {
            get {
                return _x;
            }
            set {
                // The X value is limited here and can never exceed the size of the platform
                if (value <= 5 && value > 0) _x = value;
            }
        }

        public int? Y {
            get {
                return _y;
            }
            set {
                // The X value is limited here and can never exceed the size of the platform
                if (value <= 5 && value > 0) _y = value;
            }
        }

        public Well[,] Wells {
            get {
                return _wells;
            }
        } 

        public Well GetWell(int? x, int? y) {
            // If either value hasn't been set yet, do nothing.
            if (x == null || y == null) return null;
            return _wells[(int)x-1,(int)y-1];
        }

        // It's a little sloppy, but it helps me achieve the data structure I wanted for my wells;
        private Well[,] InstanciateWells() {
            var newWellArray = new Well[5,5];

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    newWellArray[i,j] = new Well();
                }
            }

            return newWellArray;
        }
    }
}