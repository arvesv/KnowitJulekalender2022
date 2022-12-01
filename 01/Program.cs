using System.Net;

// Helper functions
async Task<string> DownloadFileFromTheInternetAsync(string uri)
{
    using var client = new HttpClient();

    using var response = await client.GetAsync(uri);
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadAsStringAsync();
}





// Read the dictionary into a Dictionary
const string dictionaryUrl = "https://julekalender-backend.knowit.no/rails/active_storage/blobs/redirect/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBb1VEIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--2f6bcd547b6ffe889579dd8a1af8249693a333d7/dictionary.txt?disposition=inline";
string body = await DownloadFileFromTheInternetAsync(dictionaryUrl);
var z = body
    .Split('\n')
    .Where(x => !string.IsNullOrEmpty(x) )
    .Select(x => x.Split(','))
    .ToDictionary<string[], string, string>(
        r => r[0],
        r => r[1]
    );


Console.WriteLine(body);

const string wishlistUrl = "https://julekalender-backend.knowit.no/rails/active_storage/blobs/redirect/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBdkFDIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--7400c6d0a99d17a53b0cdcb0b32a40026c0b44a2/letter.txt?disposition=inline";
string wishlist = await DownloadFileFromTheInternetAsync(wishlistUrl);

int i = 0;
string result = "";

do {
    string substr = wishlist.Substring(i);
    foreach(var key in z.Keys)  {
        if(substr.StartsWith(key)) {
            result += z[key];
            result += " ";
            i += key.Length;
        }
    }
} while(i < wishlist.Length);





Console.WriteLine(result);