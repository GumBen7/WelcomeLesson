namespace Term {
    class Terminal {
        public int Index {get; private set;} = 0;
        public int LineIndex {get; private set;} = 0;
        public List<List<char>> Body {get; init;} = new List<List<char>>();

        public Terminal() {
            Body.Add(new List<char>());
        }

        public void AddChar(char c) {
            Body[LineIndex].Insert(Index, c);
            ++this.Index;
        }

        public void MoveLeft() {
            if (Index != 0) {
                --this.Index;
            }
        }

        public void MoveRight() {
            if (Index < Body[LineIndex].Count) {
                ++this.Index;
            }
        }

        public void MoveToEnd() {
            this.Index = Body[LineIndex].Count;
        }

        public void MoveToStart() {
            this.Index = 0;
        }

        public void MoveUp() {
            if (LineIndex != 0) {
                --this.LineIndex;
            }
        }

        public void MoveDown() {
            if (LineIndex < Body.Count - 1) {
                ++this.LineIndex;
            }
        }

        public void NewLine() {
            Body.Insert(LineIndex+1, new List<char>(Body[LineIndex].GetRange(Index, Body[LineIndex].Count - Index)));
            Body[LineIndex].RemoveRange(Index, Body[LineIndex].Count - Index);
            this.Index = 0;
            ++this.LineIndex;
        }

        public override string ToString() {
            string res = "";
            foreach (var l in Body) {
                res += new string(l.ToArray());
                res += "\n";
            }
            return res;
        }
    }
}