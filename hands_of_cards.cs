class Card {
    public int rank;     // 1 = Ace, 2 .. 10, 11 = Jack, 12 = Queen, 13 = King 
    public char suit;   // 'C', 'D', 'H' or 'S'
    public string[] rank_array = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

    public Card(string s) {
        string rank_ = s[..(s.Length - 1)];
        for (int i = 0 ; i < 13 ; ++i) {
            if (rank_array[i] == rank_) {
                this.rank = i + 1;
            }
        }

        this.suit = s[s.Length - 1];
    }
}

class Hand {
    public Card[] deck = new Card[5];

    public Hand(string s) {
        string[] cards_arr = s.Split(' ');

        for (int i = 0 ; i < 5 ; ++i) {
            this.deck[i] = new Card(cards_arr[i]);
        }
    }

    public (int r, int n) get_score(params int[] deck) {
        (int r, int n) score = (0, 0);
        int score_ace = deck[0];

        for (int i = 12 ; i >= 0 ; --i) {

            // 4 of a kind
            if (deck[i] == 4) {
                score.n = 4;
                score.r = i + 1;
                break;
            }

            // 3 of a kind
            if (deck[i] == 3 && score.n < 3) { 
                score.n = 3;
                score.r = i + 1;
            }

            // 2 of a kind
            if (deck[i] == 2 && score.n < 2) {
                score.n = 2;
                score.r = i + 1;
            }
            
            // no pair
            if (deck[i] == 1 && score.n < 1) {
                score.n = 1;
                score.r = i + 1;
            }
        }

        if (score_ace == score.n) score.r = 14;
        return score; 
    }

    public int compare(Hand h) {
        int[] deck_1 = new int[13];
        int[] deck_2 = new int[13];

        (int r, int n)  score_1;
        (int r, int n) score_2;

        for (int i = 0 ; i < 5 ; ++i) {
            deck_1[this.deck[i].rank - 1] += 1;
        }

        for (int i = 0 ; i < 5 ; ++i) {
            deck_2[h.deck[i].rank - 1] += 1;
        }

        score_1 = get_score(deck_1);
        score_2 = get_score(deck_2);

        if (score_1.n > score_2.n) return 1;
        else if (score_1.n < score_2.n) return -1;

        else if (score_1.n == score_2.n) {
            if (score_1.r > score_2.r) return 1;
            else if (score_1.r < score_2.r) return -1;
        }

        return 0;
    }
}

