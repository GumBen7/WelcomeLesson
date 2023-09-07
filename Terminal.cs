namespace Term {
    class Terminal {
        public int Index {get; private set;} = 0;
        public int LineIndex {get; private set;} = 0;
        public List<List<char>> Body {get; private set;} = new List<List<char>> { new() };
        private string LogString {get; set;} = "";

        public void AddChar(char c) => Body[LineIndex].Insert(Index++, c);

        public void MoveToStart() => Index = 0;
        
        public void MoveToEnd() => Index = Body[LineIndex].Count;
        
        public void MoveLeft() {
            if (Index != 0) {
                --Index;
            }
        }

        public void MoveRight() {
            if (Index < Body[LineIndex].Count) {
                ++Index;
            }
        }

        public void MoveUp() {
            if (LineIndex != 0) {
                --LineIndex;
            }
        }

        public void MoveDown() {
            if (LineIndex < Body.Count - 1) {
                ++LineIndex;
            }
        }

        public void NewLine(char c = '\0') {
            Body.Insert(LineIndex+1, new List<char>(Body[LineIndex].GetRange(Index, Body[LineIndex].Count - Index)));
            Body[LineIndex].RemoveRange(Index, Body[LineIndex].Count - Index);
            Index = 0;
            ++LineIndex;
        }

        public string Process(params string[] commands) {
            foreach (var command in commands) {
                foreach (var c in command.ToCharArray()) {
                    switch (c) {
                        case 'L':
                            MoveLeft();
                            break;
                        case 'R':
                            MoveRight();
                            break;
                        case 'E':
                            MoveToEnd();
                            break;
                        case 'B':
                            MoveToStart();
                            break;
                        case 'N':
                            NewLine();
                            break;
                        case 'U':
                            MoveUp();
                            break;
                        case 'D':
                            MoveDown();
                            break;
                        default:
                            AddChar(c);
                            break;
                    }   
                }
                Log();
                Reset();
            }
            return ToString();
        }

        private void Log() {
            foreach (var l in Body) {
                LogString += new string(l.ToArray()) + "\n";
            }
            LogString += "-\n";
        }

        private void Reset() {
            Index = 0;
            LineIndex = 0;
            Body = new List<List<char>> { new() };
        }
        
        public override string ToString() => LogString;
    }
}