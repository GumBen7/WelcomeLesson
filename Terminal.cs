namespace Term {
    /// <summary>
    /// Класс <c>Terminal</c> моделирует простейший терминал
    /// </summary>
    class Terminal {
        /// <value>
        /// Свойство <c>Index</c> представляет индекс курсора в текущей строке 
        /// </value>
        public int Index {get; private set;} = 0;
        /// <value>
        /// Свойство <c>LineIndex</c> представляет строчный индекс курсора 
        /// </value>
        public int LineIndex {get; private set;} = 0;
        /// <value>
        /// Свойство <c>Body</c> представляет тело териманала, где внешний лист хранит строки в виде листов символов  
        /// </value>
        public List<List<char>> Body {get; private set;} = new List<List<char>> { new() };
        /// <value>
        /// Свойство <c>LogString</c> представляет строку с результатом работы терминала
        /// </value>
        private string LogString {get; set;} = "";

        /// <summary>
        /// Этот метод добавляет символ на текущем месте курсора
        /// </summary>
        /// <param name="c">Добавляемый символ</param>
        public void AddChar(char c) => Body[LineIndex].Insert(Index++, c);

        /// <summary>
        /// Этот метод двигает курсор на начало текущей строки
        /// </summary>
        public void MoveToStart() => Index = 0;
        
        /// <summary>
        /// Этот метод двигает курсор на конец текущей строки
        /// </summary>
        public void MoveToEnd() => Index = Body[LineIndex].Count;
        
        /// <summary>
        /// Этот метод двигает курсор на одну позицию влево в текущей строке, если это возможно
        /// </summary>
        public void MoveLeft() {
            if (Index != 0) {
                --Index;
            }
        }

        /// <summary>
        /// Этот метод двигает курсор на одну позицию вправо в текущей строке, если это возможно
        /// </summary>
        public void MoveRight() {
            if (Index < Body[LineIndex].Count) {
                ++Index;
            }
        }

        /// <summary>
        /// Этот метод двигает курсор на одну позицию выше по строкам, если это возможно
        /// </summary>
        public void MoveUp() {
            if (LineIndex != 0) {
                --LineIndex;
            }
        }

        /// <summary>
        /// Этот метод двигает курсор на одну позицию ниже по строкам, если это возможно
        /// </summary>
        public void MoveDown() {
            if (LineIndex < Body.Count - 1) {
                ++LineIndex;
            }
        }

        /// <summary>
        /// Этот метод вставляет новую строку на месте курсора, пермещая туда конец текущей строки 
        /// </summary>
        public void NewLine() {
            Body.Insert(LineIndex+1, new List<char>(Body[LineIndex].GetRange(Index, Body[LineIndex].Count - Index)));
            Body[LineIndex].RemoveRange(Index, Body[LineIndex].Count - Index);
            Index = 0;
            ++LineIndex;
        }

        /// <summary>
        /// Этот метод принимает переменное количество команд в виде строк и по очереди их выполняет
        /// </summary>
        /// <param name="commands">Массив комманд в виде строк</param>
        /// <returns>Строка с результатом работы терминала</returns>
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
            return LogString;
        }

        /// <summary>
        /// Этот метод добавляет новый результат в строку результата работы в терминал
        /// </summary>
        private void Log() {
            foreach (var l in Body) {
                LogString += new string(l.ToArray()) + "\n";
            }
            LogString += "-\n";
        }

        /// <summary>
        /// Этот метод сбрасывает индексы курсора и тело терминала
        /// </summary>
        private void Reset() {
            Index = 0;
            LineIndex = 0;
            Body = new List<List<char>> { new() };
        }
        
        public override string ToString() => LogString;
    }
}