using static System.Console;

class num_wheel {
    static void Main(){
        int N = int.Parse(ReadLine()!);

        int n = 0;
        int d = 0;

        // iterating over every possibility
        for (int i = 0 ; i <= N; i++) {
            
            for (int j = 0 ; j <= N; j++) {
                
                for (int k = 0 ; k <= N; k++) {
                    d += 1; // counting possibilities
                    if ((i + j + k) % 10 == 0) {
                        n += 1; // counting correct possibilities
                    }
                }
            }
        }

        // finding gcd(d,n)
        int a = d;
        int b = n;

        while (b > 0) {
            int temp = a;
            a = b;
            b = temp % b;
        }

        int gcd = a;

        // simplyfying probability
        n /= gcd;
        d /= gcd;

        // printing simplified probability
        WriteLine($"{n}/{d}");

    }
    
}

