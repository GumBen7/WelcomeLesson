namespace Term {
    class Program {
        static void Main(string[] args) {
            var commands = new List<string>();            
            using (var sr = new StreamReader("input.txt")) {
                var n = int.Parse(sr.ReadLine());
                for (var i = 0; i < n; ++i) {
                    commands.Add(sr.ReadLine());
                }
            }
            var term = new Terminal();
            using var sw = new StreamWriter("output.txt");
            sw.Write(term.Process(commands.ToArray()));

            var term2 = new Terminal();
            term2.Process("abNcdLLLeUfNxNx");
            Console.WriteLine(term2);
        }
    }
}