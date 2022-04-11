namespace hangmanlast
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] wordList = { "bob", "lisa", "elsie", "tractor", "car" };

            hangman hg = new hangman(10, wordList);

            hg.StartAgainGame();
        }
    }
}
