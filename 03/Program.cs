
const int maxwidth = 110;

int PapirBruk(int x, int y, int z)
{
    // Alle rekkefølgene. Kan dette gjøres mer elegant?
    IList<int[]> permutations = new List<int[]>{
        new int[]{x,y,z},
        new int[]{x,z,y},
        new int[]{y,z,x},
    };

    // Finn de to sidene som tilsammen er nærmest maxwidth/2
    var winners = permutations
        .Where(e => ((e[0]+e[1]) * 2 <= maxwidth))
        .OrderByDescending(e => e[0]+e[1]);

    if(winners.Count() > 0) {
        var winner = winners.First();

        // Papirforbruket er den 'ubrukte' siden + korteste av de gjenværende
        return winner[2] + int.Min(winner[0], winner[1]);
    }


permutations = new List<int[]>{
        new int[]{x,y,z},
        new int[]{x,z,y},
        new int[]{y,x,z},
        new int[]{y,z,x},
        new int[]{z,x,y},
        new int[]{z,y,x},
    };

    winners = permutations
        .Where(e => ((e[0]*2+e[1]) <= maxwidth))
        .OrderByDescending(e => e[0]*2+e[1]);

    if(winners.Count() > 0) {
        var winner = winners.First();

        // Papirforbruket er den 'ubrukte' siden + korteste av de gjenværende
        return 2* (winner[2] + int.Min(winner[0], winner[1]));
    }

    int[] qwa = new int[] {x, y, z};
    var q = qwa.Order().Skip(1);
    var we = q.Sum();
    return we;  
}


// Tests
Console.WriteLine($"Sum av 30,30,20 skal være 50, er {PapirBruk(30,30,20)}");
Console.WriteLine($"Sum av 30,30,30 skal være 120, er {PapirBruk(30,30,30)}");
Console.WriteLine($"Sum av 25,30,20 skal være 45, er {PapirBruk(25,30,20)}");
Console.WriteLine($"Sum av 30,35,40 skal være 130, er {PapirBruk(30,35,40)}");
Console.WriteLine($"Sum av 15, 58, 130,skal være 130, er {PapirBruk(15,58,130)}");

string url = "https://julekalender-backend.knowit.no/rails/active_storage/blobs/redirect/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBam9EIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--dac14d3d53d7b4014d5bb9b28c8679fd2e3ccdf9/pakker.csv?disposition=inline";



var z = await new HttpClient().GetAsync(url);
z.EnsureSuccessStatusCode();
var st = (await z.Content.ReadAsStringAsync()).Split('\n').Skip(1).Where(x => !String.IsNullOrEmpty(x));

int sum = 0;

foreach(var line in st) {
    
    var qw = line.Split(',').Select(r => int.Parse(r)).ToArray();


    int w = PapirBruk(qw[0], qw[1], qw[2]);

    sum += w;
}

Console.WriteLine(sum);





