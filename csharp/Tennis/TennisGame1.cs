namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (m_score1 == m_score2)
                return EqualScoresCase();
            else if (m_score1 >= 4 || m_score2 >= 4)
                return ScoresOver4Case(); 
            return NormalScoreCase();
        }

        private string NormalScoreCase()
        {
            return $"{ScoresText(m_score1)}-{ScoresText(m_score2)}";
        }

        private string ScoresText(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ThrowInvalidScoreException()
            };
        }

        private static string ThrowInvalidScoreException()
           => throw new System.Exception("Invalid score");
        

        private string ScoresOver4Case()
        {
            var minusResult = GetScoreDifference();
            if (minusResult == 1) return "Advantage player1";
            else if (minusResult == -1) return "Advantage player2";
            else if (minusResult >= 2) return "Win for player1";
            else
                return "Win for player2";
        }
        private int GetScoreDifference() => m_score1 - m_score2;
        private string EqualScoresCase()
        {
            string score = "";
            switch (m_score1)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;

            }

            return score;
        }
    }
    
    
}

