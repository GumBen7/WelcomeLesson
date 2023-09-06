namespace Term {
    class Program {
        static void Main(string[] args) {
            /*int n =  int.Parse(Console.ReadLine());
            for (var i = 0; i < n; ++i) {
                var s = Console.ReadLine();
            }*/
            var s = Console.ReadLine();
            var term = new Terminal();
            foreach (var c in s.ToCharArray()) {
                if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9') {
                    term.AddChar(c);
                } 
                else if (c == 'L') {
                    term.MoveLeft();
                }
                else if (c == 'R') {
                    term.MoveRight();
                }
                else if (c == 'E') {
                    term.MoveToEnd();
                }
                else if (c == 'B') {
                    term.MoveToStart();
                }
                else if (c == 'N') {
                    term.NewLine();
                }
                else if (c == 'U') {
                    term.MoveUp();
                } 
                else if (c == 'D') {
                    term.MoveDown();
                }
            }
            Console.WriteLine(term);
        }
    }
}