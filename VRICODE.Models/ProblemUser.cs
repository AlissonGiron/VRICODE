namespace VRICODE.Models
{
    public class ProblemUser
    {
        public int NidProblem { get; set; }
        public Problem Problem { get; set; }

        public int NidUser { get; set; }
        public User User { get; set; }

        public int QtyTries { get; set; }

        public bool FlgProblemCleared { get; set; }
    }
}
