using MultiTenancy.Web.Model;

namespace MultiTenancy.Web.Services
{
    public class ScoreCalculator : IScoreCalculator
    {
        public decimal Calculate(Game game, Player player)
        {
            return 5;//chosen by a dice roll, guarnteed to be random
        }
    }
}