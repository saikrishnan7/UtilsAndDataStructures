namespace Problems
{
    public class CtCiDp
    {
        public int TripleStep(int n)
        {
            var memo = new int[n + 1];
            memo[0] = 1;
            memo[1] = 1;
            memo[2] = 2;
            return TripleStepHelper(n, memo);
        }

        private int TripleStepHelper(int n, int[] memo)
        {
            if (n == 0 || n == 1)
                return 1;
            if (n == 2)
                return 2;
            if (memo[n] == 0)
                memo[n] = TripleStepHelper(n - 1, memo) + TripleStepHelper(n - 2, memo) + TripleStepHelper(n - 3, memo);

            return memo[n];
        }
    }
}
