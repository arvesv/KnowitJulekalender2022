var url =
    "https://julekalender-backend.knowit.no/rails/active_storage/blobs/redirect/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBamNEIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--3770564b85106cc053f6546adb816d383189d58b/gaver.txt?disposition=inline";

var z = await new HttpClient().GetAsync(url);
z.EnsureSuccessStatusCode();
var st = (await z.Content.ReadAsStringAsync()).Split('\n').Where(x => !String.IsNullOrEmpty(x));


var backItems = 0;
var lines = 0;


foreach (var item in st)
{
    lines += 2;

    if (backItems >= 3)
    {
        lines += backItems - 2;
    }

    if (!item.Contains("alv"))
        backItems++;


}

Console.WriteLine(lines);